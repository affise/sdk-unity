using System.IO;
using UnityEditor;
using UnityEngine;

namespace AffiseAttributionLib.Editor.Menu
{
    internal static class AffiseSettingsMenuItems
    {
        private const string FileName = "Affise Settings";
        private const string FileFolder = "Assets/Affise/Resources";

        [MenuItem("Assets/Create/Affise/" + FileName, false)]
        public static void CreateAssetWithMakeActiveDialog()
        {
            var settings = CreateAsset();
            if (settings is null) return;

            if (EditorUtility.DisplayDialog(
                    "Active affise settings",
                    "Do you wish to make this asset the active affise settings? " +
                    "The active affise settings will be included into any builds and preloaded at the start. " +
                    "This can be changed at 'Edit/Project Settings/Affise'",
                    "Yes",
                    "No"
                ))
            {
                AffiseEditorSettings.Set(settings);
            }
        }

        public static AffiseSettings CreateAsset()
        {
            var folder = Directory.CreateDirectory(FileFolder);
            var path = EditorUtility.SaveFilePanelInProject(
                "Save Settings",
                FileName,
                "asset",
                "Please enter a filename to save the projects settings to.",
                folder.FullName
            );

            if (string.IsNullOrEmpty(path))
                return null;

            var settings = ScriptableObject.CreateInstance<AffiseSettings>();
            settings.name = "Default Affise Settings";

            AssetDatabase.CreateAsset(settings, path);
            AssetDatabase.SaveAssets();

            return settings;
        }
    }
}