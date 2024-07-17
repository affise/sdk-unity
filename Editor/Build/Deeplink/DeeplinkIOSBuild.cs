#if UNITY_IOS
#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        // Deelinks
        private const string CFBundleURLTypes = "CFBundleURLTypes";
        private const string CFBundleTypeRole = "CFBundleTypeRole";
        private const string CFBundleURLName = "CFBundleURLName";
        private const string CFBundleURLSchemes = "CFBundleURLSchemes";
        // Applinks
        private const string ApplinksKey = "com.apple.developer.associated-domains";
        private const string ApplinkPrefix = "applinks:";

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

            var links = AffiseEditorConfig.Instance.deeplinks
	            .Where(x => !string.IsNullOrWhiteSpace(x))
	            .Select(x => x! )
	            .ToList();

            var deeplinks = links.Where(f => f?.StartsWith("http") == false).ToList();
            var applinks = links.Where(f => f?.StartsWith("http") == true).ToList();

            hasChanged |= RemoveDeeplinks(rootDict);
            hasChanged |= RemoveApplinks(rootDict);
            hasChanged |= AddDeeplinks(rootDict, deeplinks);
            hasChanged |= AddApplinks(rootDict, applinks);

            if (!hasChanged) return;
            // Write to file
            File.WriteAllText(plistPath, plist.WriteToString());
        }

        #region Deeplinks
        
        private bool RemoveDeeplinks(PlistElementDict root)
        {
	        root.values.Remove(CFBundleURLTypes);
	        return true;
        }

        private bool AddDeeplinks(PlistElementDict root, List<string> deeplinks)
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
        
        #endregion // Deeplinks

        #region Applinks

        private bool RemoveApplinks(PlistElementDict root)
        {
	        root.values.Remove(ApplinksKey);
	        return true;
        }
        
        private bool AddApplinks(PlistElementDict root, List<string> applinks)
        {
	        var array = root.CreateArray(ApplinksKey);
            
	        var hasChanged = false;
	        foreach (var applink in applinks)
	        {
		        array.AddString($"{ApplinkPrefix}{applink}");

		        hasChanged = true;
	        }

	        return hasChanged;
        }

        #endregion // Applinks
        
        private (string?, string?) GetSchemeAndHost(string deeplink)
        {
	        var parts = deeplink.Split("://");
	        if (parts?.Length != 2) return (null, null);
	        return (parts[0], parts[1]);
        }
    }
}

#endif // UNITY_IOS