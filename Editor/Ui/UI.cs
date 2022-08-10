using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

namespace AffiseAttributionLib.Editor.Ui
{
    public static class UI
    {
        private const string k_ResourceRoot = "Layouts";
        
        private static string ResourcePath(string filename) => Path.Combine(k_ResourceRoot, filename); 
        
        public static VisualTreeAsset Get(string uxmlFile)
        {
            var path = ResourcePath(uxmlFile);
            var asset = Resources.Load<VisualTreeAsset>(path);

            if (asset == null)
                throw new FileNotFoundException("Failed to load UI Template at path " + path);
            return asset;
        }
        
        public static StyleSheet GetStyle(string ussFile)
        {
            var path = ResourcePath(ussFile);
            var asset = Resources.Load<StyleSheet>(path);

            if (asset == null)
                throw new FileNotFoundException("Failed to load UI Style at path " + path);
            return asset;
        }
    }
}