#if UNITY_IOS
#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using AffiseAttributionLib.Editor.Config;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

namespace AffiseAttributionLib.Editor.Build.Deeplink
{
    internal class DeeplinkIOSBuild
    {
        [PostProcessBuild]
        public static void OnPostProcessBuild(BuildTarget target, string pathToBuiltProject)
        {
            if (target != BuildTarget.iOS) return;
            var plistPath = Path.Join(pathToBuiltProject, InfoPlist);
            if (plistPath is null) return;
            
            new DeeplinkIOSBuild().UpdatePlistDocument(plistPath);
        }
        
        private const string InfoPlist = "Info.plist";
        private const string CFBundleURLTypes = "CFBundleURLTypes";
        private const string CFBundleTypeRole = "CFBundleTypeRole";
        private const string CFBundleURLName = "CFBundleURLName";
        private const string CFBundleURLSchemes = "CFBundleURLSchemes";

        private void UpdatePlistDocument(string plistPath)
        {
            if (AffiseEditorConfig.Instance is null) return;
            if (AffiseEditorConfig.Instance.deeplinksEnabled == false) return;
            if (AffiseEditorConfig.Instance.deeplinks.Count == 0) return;
            
            // Get plist
            var plist = new PlistDocument();
            plist.ReadFromString(File.ReadAllText(plistPath));
            // Get root
            var rootDict = plist.root;

            var hasChanged = false;

            hasChanged |= RemoveDeeplinks(rootDict);
            hasChanged |= AddDeeplinks(rootDict, AffiseEditorConfig.Instance.deeplinks);

            if (!hasChanged) return;
            // Write to file
            File.WriteAllText(plistPath, plist.WriteToString());
        }

        private bool RemoveDeeplinks(PlistElementDict root)
        {
            root.values.Remove(CFBundleURLTypes);
            return true;
        }

        private bool AddDeeplinks(PlistElementDict root, List<string?> deeplinks)
        {
            var array = root.CreateArray(CFBundleURLTypes);
            
            var hasChanged = false;
            foreach (var deeplink in deeplinks)
            {
	            var (scheme, host) = GetSchemeAndHost(deeplink);
	            if (string.IsNullOrWhiteSpace(scheme) || string.IsNullOrWhiteSpace(host)) continue;
	            
	            var dict = array.AddDict();
	            
	            dict.SetString(CFBundleTypeRole, "Editor");
	            dict.SetString(CFBundleURLName, host);

	            var schemes = dict.CreateArray(CFBundleURLSchemes);
	            schemes.AddString(scheme);

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

#endif // UNITY_IOS