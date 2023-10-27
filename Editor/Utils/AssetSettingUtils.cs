#nullable enable
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AffiseAttributionLib.Editor.Menu;
using AffiseAttributionLib.Unity;
using UnityEditor;
using UnityEngine;

namespace AffiseAttributionLib.Editor.Utils
{
    internal static class AssetSettingUtils
    {
        public static void SetNoActive()
        {
            SetActive(null);
        }

        public static void SetActive(AffiseSettings? settings)
        {
            AssetDatabase.DisallowAutoRefresh();
            foreach (var asset in GetAll())
            {
                if (asset is null) continue;
                if (asset == settings) continue;
                asset.isActive = false;
                EditorUtility.SetDirty(asset);
            }

            AssetDatabase.SaveAssets();

            if (settings is null) return;
            settings.isActive = true;
            EditorUtility.SetDirty(settings);
            AssetDatabase.SaveAssets();
            AssetDatabase.AllowAutoRefresh();
        }

        public static AffiseSettings? GetActiveOrFirst()
        {
            return GetActive() ?? GetFirst();
        }

        public static AffiseSettings? GetActive()
        {
            foreach (var asset in GetAll())
            {
                if (asset is null) continue;
                if (asset.isActive) return asset;
            }

            return null;
        }

        public static AffiseSettings? GetFirst()
        {
            return GetAll().FirstOrDefault();
        }

        private static IEnumerable<AffiseSettings> GetAll()
        {
            return GetAllPaths()
                .Select(AssetDatabase.LoadAssetAtPath<AffiseSettings>);
        }

        private static IEnumerable<string> GetAllPaths()
        {
            return AssetDatabase
                .FindAssets($"t:{typeof(AffiseSettings)}")
                .Select(AssetDatabase.GUIDToAssetPath);
        }

        public static bool CheckFolder(Object? assetObject)
        {
            if (assetObject is null) return false;
            return CheckFolder(AssetDatabase.GetAssetPath(assetObject));
        }

        private static bool CheckFolder(string path)
        {
            return Regex
                .Match(path, "(\\\\||\\/)Resources(\\\\|\\/)", RegexOptions.IgnoreCase)
                .Success;
        }

        public static AffiseSettings Create()
        {
            return AffiseSettingsMenuItems.CreateAsset();
        }
    }
}