using System.IO;
using UnityEditor;
using UnityEngine;

namespace AffiseAttributionLib.Editor.Menu
{
    public static class AffiseSettingsMenuItems
    {
        private const string k_Name = "Affise Settings";
        private const string k_Dir = "Assets/Affise/Resources";

        [MenuItem("Assets/Create/Affise/" + k_Name, false)]
        public static void CreateAssetWithMakeActiveDialog()
        {
            var ls = CreateAsset();
            if (ls == null)
                return;

            if (EditorUtility.DisplayDialog(
                    "Active affise settings",
                    "Do you wish to make this asset the active affise settings? " +
                    "The active affise settings will be included into any builds and preloaded at the start. " +
                    "This can be changed at 'Edit/Project Settings/Affise'",
                    "Yes",
                    "No"
                ))
            {
                AffiseEditorSettings.ActiveSettings = ls;
            }
        }

        public static AffiseSettings CreateAsset()
        {
            var folder = Directory.CreateDirectory(k_Dir);
            var path = EditorUtility.SaveFilePanelInProject(
                "Save Settings",
                k_Name,
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