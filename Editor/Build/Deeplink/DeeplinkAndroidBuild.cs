#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using AffiseAttributionLib.Editor.Config;
using AffiseAttributionLib.Editor.Extensions;
using AffiseAttributionLib.Editor.Utils;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace AffiseAttributionLib.Editor.Build.Deeplink
{
    public class DeeplinkAndroidBuild : IPreprocessBuildWithReport
    {
        private const string TemplateAndroidManifest = "AffiseTemplateAndroidManifest.xml";
        private const string AndroidManifestPath = "Plugins/Android";
        private const string AndroidManifestName = "AndroidManifest.xml";
        private const string XpathActivity = "/manifest/application/activity";
        private const string XpathIntentFilter = "intent-filter[data/@android:scheme and data/@android:host]";

        #region intent-filter keys

        private const string IntentFilterName = "intent-filter";
        private const string CategoryName = "category";
        private const string ActionName = "action";
        private const string DataName = "data";

        private const string ViewValue = "android.intent.action.VIEW";
        private const string DefaultValue = "android.intent.category.DEFAULT";
        private const string BrowsableValue = "android.intent.category.BROWSABLE";

        private const string AttributeKey = "name";
        private const string SchemeKey = "scheme";
        private const string HostKey = "host";

        private readonly Dictionary<Tuple<string, string>, string> _intentMap = new()
        {
            { new Tuple<string, string>(AttributeKey, ViewValue), ActionName },
            { new Tuple<string, string>(AttributeKey, DefaultValue), CategoryName },
            { new Tuple<string, string>(AttributeKey, BrowsableValue), CategoryName },
        };

        private readonly XmlDocument _xml = new XmlDocument();
        private XmlNamespaceManager? _ns;

        #endregion intent-filter keys

        public int callbackOrder => 0;

        public void OnPreprocessBuild(BuildReport report)
        {
            if (report.summary.platform != BuildTarget.Android) return;
            if (AffiseEditorConfig.Instance is null) return;
            if (AffiseEditorConfig.Instance.deeplinksEnabled == false) return;
            if (AffiseEditorConfig.Instance.deeplinks.Count == 0) return;

            var appManifestPath = ManifestFile();
            if (string.IsNullOrWhiteSpace(appManifestPath)) return;

            _xml.Load(appManifestPath);
            _ns = _xml.Namespace();
            
            if (_xml.DocumentElement is null) return;
            var activityNode = _xml.DocumentElement.SelectSingleNode(XpathActivity, _ns);
            
            var hasChanged = false;

            hasChanged |= RemoveDeeplinks(activityNode);
            hasChanged |= AddDeeplinks(activityNode, AffiseEditorConfig.Instance.deeplinks);

            if (!hasChanged) return;
            // Save the changes.
            _xml.Save(appManifestPath);
        }

        private string? ManifestFile()
        {
            var androidPluginsPath = Path.Combine(Application.dataPath, AndroidManifestPath);
            var manifestPath = Path.Combine(androidPluginsPath, AndroidManifestName);

            if (!File.Exists(manifestPath))
            {
                if (!Directory.Exists(androidPluginsPath))
                {
                    Directory.CreateDirectory(androidPluginsPath);
                }

                var manifestTemplate = Asset.Get(TemplateAndroidManifest);
                if (string.IsNullOrWhiteSpace(manifestTemplate))
                {
                    Debug.Log("AndroidManifest: is empty");
                    return null;
                }

                File.WriteAllText(manifestPath, manifestTemplate);
            }

            return File.Exists(manifestPath) ? manifestPath : null;
        }

        private bool RemoveDeeplinks(XmlNode? activityNode)
        {
            if (activityNode is null) return false;
            
            var it = activityNode.SelectNodes(XpathIntentFilter, _ns)?.GetEnumerator();
            if (it is null) return false;
            var hasChanged = false;
            while (it.MoveNext())
            {
                if (it.Current is XmlNode intentFilter)
                {
                    activityNode.RemoveChild(intentFilter);
                    hasChanged = true;
                }
            }

            return hasChanged;
        }

        private bool AddDeeplinks(XmlNode? activityNode, List<string?> deeplinks)
        {
            if (activityNode is null) return false;
            
            var hasChanged = false;
            foreach (var deeplink in deeplinks)
            {
                var (scheme, host) = GetSchemeAndHost(deeplink);
                if (string.IsNullOrWhiteSpace(scheme) || string.IsNullOrWhiteSpace(host)) continue;

                var intentFilter = _xml.CreateElement(IntentFilterName)
                    .AppendTo(activityNode);

                foreach (var ((key, value), name) in _intentMap)
                {
                    _xml.CreateElement(name)
                        .AddAttribute(_xml, key, value)
                        .AppendTo(intentFilter);
                }

                _xml.CreateElement(DataName)
                    .AddAttribute(_xml, SchemeKey, scheme)
                    .AddAttribute(_xml, HostKey, host)
                    .AppendTo(intentFilter);

                hasChanged = true;
            }

            return hasChanged;
        }

        private Tuple<string, string>? GetSchemeAndHost(string? deeplink)
        {
            if (string.IsNullOrWhiteSpace(deeplink)) return null;
            var parts = deeplink?.Split("://");
            if (parts is null) return null;
            if (parts.Length != 2) return null;
            return new Tuple<string, string>(parts[0], parts[1]);
        }
    }
}