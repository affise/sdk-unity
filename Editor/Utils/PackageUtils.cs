using System;
using System.Linq;
using SimpleJSON;
using UnityEditor;
using UnityEngine;
using PackageInfo = UnityEditor.PackageManager.PackageInfo;

namespace AffiseAttributionLib.Editor.Utils
{
    public static class PackageUtils
    {
        private const string k_AssetsFolder = "Assets";
        private const string k_PackageAsset = "package";
        private const string k_PackageDisplayName = "displayName";

        public static void Find(string search, Action<PackageInfo> onResult, Action onNoResult,
            bool strict = false)
        {
            foreach (var package in PackageInfo.GetAllRegisteredPackages())
            {
                if (IsSkip(package.displayName, search, strict)) continue;
                onResult.Invoke(package);
                return;
            }
            onNoResult.Invoke();
        }

        public static void FindAsAsset(string search, Action<JSONObject> onResult, Action onNoResult, bool strict = false)
        {
            var assets = AssetDatabase.FindAssets(k_PackageAsset, new[] { k_AssetsFolder })
                .Select(AssetDatabase.GUIDToAssetPath)
                .Where(x => AssetDatabase.GetMainAssetTypeAtPath(x) == typeof(TextAsset))
                .Select(AssetDatabase.LoadAssetAtPath<TextAsset>)
                .ToList();

            foreach (var asset in assets)
            {
                JSONObject json;
                try
                {
                    json = JSON.Parse(asset.text).AsObject;
                }
                catch (Exception)
                {
                    Debug.LogWarning($"Can't parse json [ {AssetDatabase.GetAssetPath(asset)} ]");
                    continue;
                }

                var displayName = json[k_PackageDisplayName];
                if (displayName is null) continue;
                if (IsSkip(displayName.ToString(), search, strict)) continue;
                onResult.Invoke(json);
                return;
            }
            onNoResult.Invoke();
        }

        private static bool IsContains(string source, string search) =>
            source.Contains(search, StringComparison.OrdinalIgnoreCase);

        private static bool IsMatch(string source, string search) =>
            source.Equals(search, StringComparison.OrdinalIgnoreCase);

        private static bool IsSkip(string source, string search, bool strict = false) =>
            (strict
                ? IsMatch(source, search)
                : IsContains(source, search)
            ) == false;
    }
}