#nullable enable
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace AffiseAttributionLib.Editor.Utils
{
    internal static class Asset
    {
        public static string? Get(string name)
        {
            var args = name.Split('.').ToList();
            if (args.Count == 0) return null;
            if (args.Count >= 2)
            {
                args.RemoveAt(args.Count - 1);
            }
            var searchName = string.Join(".", args);
            
            try
            {
                return AssetDatabase
                    .FindAssets(searchName)
                    .Select(AssetDatabase.GUIDToAssetPath)
                    .Where(x => x.EndsWith(name))
                    .Where(x => AssetDatabase.LoadAssetAtPath<TextAsset>(x) is not null)
                    .Select(s => AssetDatabase.LoadAssetAtPath<TextAsset>(s).text)
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                // ignored
                Debug.LogError($"Not found \"{name}\": {e}");
            }

            return null;
        }
    }
}