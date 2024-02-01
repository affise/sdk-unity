#if UNITY_IOS
#nullable enable
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AffiseAttributionLib.Editor.Config;
using AffiseAttributionLib.Editor.Utils;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEditor.iOS.Xcode;

namespace AffiseAttributionLib.Editor.Build
{
    internal static class ModulesIOSPostProcessBuild
    {
        private const string PodfileName = "Podfile";
        private const string TemplateFolder = "Editor/Resources/iOS";
        private const string TemplateName = "AffisePodfile";
        private const string ModulesComment = "### BUILD SETTINGS AFFISE MODULES ###";
        private const string PodTarget = "target 'UnityFramework' do";
        private const string AffiseInternal = "pod 'AffiseInternal'";
        private const string KeyNsUserTrackingUsageDescription = "NSUserTrackingUsageDescription";

        private static string? LoadAffisePodfile()
        {
            var findAssets = AssetDatabase.FindAssets(TemplateName, null);
            if (findAssets.Length < 1) return null;
            foreach (var guid in findAssets)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                if (!assetPath.Contains(TemplateFolder)) continue;
                return AssetDatabase.LoadAssetAtPath<TextAsset>(assetPath)?.text;
            }

            return null;
        }

        private static void CopyPodfile(string? filename)
        {
            if (filename is null) return;
            if (File.Exists(filename))
            {
                Debug.LogWarning($"{PodfileName} already exists at \"{filename}\"");
                return;
            }

            var podfileContent = LoadAffisePodfile();
            if (podfileContent is null)
            {
                Debug.LogWarning($"Affise {PodfileName}.rb not found");
                return;
            }

            if (podfileContent.Trim().Length < 1)
            {
                Debug.LogWarning($"Affise {PodfileName}.rb is empty");
                return;
            }

            Debug.Log($"Creating project {PodfileName} for Affise");
            File.WriteAllText(filename, podfileContent);
            Debug.Log($"Open folder {filename} in terminal and run command: pod update");
        }

        private static void AddDependencies(string? podfilePath)
        {
            if (podfilePath is null) return;
            var result = new List<string>();

            var dependencies = AffiseEditorConfig.GetDependencies().Item2;
            var allModulesNames = AffiseEditorConfig.GetAllModulesNames().Item2;
            var iosVersion = ModulesData.GetVersion().Item2;

            var gradleContent = File.ReadAllText(podfilePath);
            var textLines = gradleContent
                .Replace("\r\n", "\n")
                .Replace("\r", "\n")
                .Split(new[] { '\n' });

            var inDependencies = false;
            var updated = false;

            foreach (var line in textLines) //line loop
            {
                if (line.Contains(PodTarget))
                {
                    inDependencies = true;
                }
                else
                {
                    switch (inDependencies)
                    {
                        // add new dependencies at section end
                        case true when line.Contains(AffiseInternal):
                        {
                            inDependencies = false;

                            result.Add($"   {ModulesComment}");
                            foreach (var dependency in dependencies) //dependencies loop
                            {
                                if (string.IsNullOrWhiteSpace(dependency.Module)) continue; //dependencies loop
                                // add new dependencies
                                result.Add($"   pod '{dependency.Module}', '{dependency.Version}'");
                            }

                            updated = true;
                            result.Add($"   {ModulesComment}");
                            break;
                        }
                        // remove all old dependencies
                        case true when allModulesNames.Any(name => line.Contains(name)):
                            updated = true;
                            continue; //line loop
                        case true when line.Contains(ModulesComment):
                            updated = true;
                            continue; //line loop
                    }
                }

                if (line.Contains(AffiseInternal) && iosVersion is not null)
                {
                    result.Add($"   {AffiseInternal}, '{iosVersion}'");
                    continue;
                }

                result.Add(line);
            }

            if (!updated) return;

            File.WriteAllText(podfilePath, string.Join("\n", result) + "\n");
        }

        private static void UpdatePlistDocument(string path)
        {
            // Get plist
            var plistPath = Path.Join(path, "Info.plist");
            if (plistPath is null) return;
            var plist = new PlistDocument();
            plist.ReadFromString(File.ReadAllText(plistPath));
            // Get root
            var rootDict = plist.root;

            var dependencies = AffiseEditorConfig.GetDependencies().Item2;
            var hasAdvertising = dependencies.Any(m => m.Module.Contains("Advertising"));

            if (hasAdvertising)
            {
                var nsUserTrackingValue = "";
                if (AffiseEditorConfig.Instance is not null)
                {
                    nsUserTrackingValue = AffiseEditorConfig.Instance.ios.nsUserTrackingUsageDescription ;
                }
                rootDict.SetString(KeyNsUserTrackingUsageDescription, nsUserTrackingValue);
            }
            else
            {       
                rootDict.values.Remove(KeyNsUserTrackingUsageDescription);
            }
           
            // Write to file
            File.WriteAllText(plistPath, plist.WriteToString());
        }

        [PostProcessBuild]
        public static void OnPostProcessBuild(BuildTarget target, string pathToBuiltProject)
        {
            if (target != BuildTarget.iOS) return;

            var filename = Path.Join(pathToBuiltProject, PodfileName);
            CopyPodfile(filename);
            AddDependencies(filename);
            UpdatePlistDocument(pathToBuiltProject);
        }
    }
}

#endif // UNITY_IOS