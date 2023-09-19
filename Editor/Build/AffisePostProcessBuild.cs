using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using Debug = UnityEngine.Debug;


namespace AffiseAttributionLib.Editor.Build
{
    internal static class AffisePostProcessBuild
    {
        private const string PodfileName = "Podfile";

        private static string LoadAffisePodfile()
        {
            var findAssets = AssetDatabase.FindAssets("AffisePodfile", null);
            if (findAssets.Length < 1) return null;
            
            foreach (var guid in findAssets)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);

                if (assetPath.Contains("Editor/Resources/iOS"))
                {
                    return AssetDatabase.LoadAssetAtPath<TextAsset>(assetPath)?.text;
                }
            }
            return null;
        }

        [PostProcessBuild]
        public static void OnPostProcessBuild(BuildTarget target, string pathToBuiltProject)
        {
            if (target != BuildTarget.iOS) return;
            
            var filename = Path.Join(pathToBuiltProject, PodfileName);
            if (File.Exists(filename))
            {
                Debug.LogWarning($"{PodfileName} already exists at {filename}");
                return;
            }

            var podfileContent = LoadAffisePodfile();
            if (podfileContent is null )
            {
                Debug.LogWarning($"Affise {PodfileName}.rb not found");
                return;
            }
            if ( podfileContent.Trim().Length < 1)
            {
                Debug.LogWarning($"Affise {PodfileName}.rb is empty");
                return;
            }
            Debug.Log($"Creating project {PodfileName} for Affise");
            File.WriteAllText(filename, podfileContent);
            
            Debug.Log($"Open folder {filename} in terminal and run command: pod update");
        }
    }
}