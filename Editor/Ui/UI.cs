#nullable enable
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

namespace AffiseAttributionLib.Editor.Ui
{
    internal static class UI
    {
        private const string ResourceRoot = "Layouts";
        
        private static string ResourcePath(string filename) => Path.Combine(ResourceRoot, filename); 
        
        public static T? GetResource<T>(string path) where T : Object
        {
            var resourcePath = ResourcePath(path);
            var asset = Resources.Load<T>(resourcePath);

            if (asset is null)
            {
                Debug.LogWarning($"Failed to load resource: \"{typeof(T).Name}\" at path: \"{resourcePath}\"");
            }
            return asset;
        }
        
        public static VisualTreeAsset? Get(string path) => GetResource<VisualTreeAsset>(path);
        
        public static StyleSheet? GetStyle(string path) => GetResource<StyleSheet>(path);
    }
}