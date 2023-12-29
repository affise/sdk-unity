#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using AffiseAttributionLib.Editor.Modules;
using SimpleJSON;
using UnityEditor;
using UnityEngine;

namespace AffiseAttributionLib.Editor.Utils
{
    internal class ModulesData
    {
        private static JSONArray? GetJson()
        {
            try
            {
                return AssetDatabase
                    .FindAssets("AffiseModules")
                    .Select(AssetDatabase.GUIDToAssetPath)
                    .Where(x => x.EndsWith("AffiseModules.json"))
                    .Where(x => AssetDatabase.LoadAssetAtPath<TextAsset>(x) is not null)
                    .Select(s => AssetDatabase.LoadAssetAtPath<TextAsset>(s).text)
                    .Select(JSON.Parse)
                    .FirstOrDefault()
                    ?.AsArray;
            }
            catch (Exception e)
            {
                // ignored
                Debug.LogError($"Affise Modules config: {e}");
            }

            return null;
        }

        public static List<Modules.Module> Get()
        {
            var json = GetJson();
            var result = new List<Modules.Module>();
            if (json is null) return result;
            
            foreach (var (_, value) in json)
            {
                var name = value["name"]?.Value;
                if (name is null) continue;
                var android = value["android"];
                var hasAndroid = HasModule(android);
                var hasIos = HasModule(value["ios"]);

                var module = new Modules.Module()
                {
                    name = name,
                    android = hasAndroid,
                    ios = hasIos,
                    androidModule = hasAndroid,
                    iosModule = hasIos,
                };

                result.Add(module);
            }
            return result;
        }

        public static Tuple<string?, string?> GetVersion()
        {
            string? androidVersion = null;
            string? iosVersion = null;

            var data = GetDependencies();
            foreach (var (_, (android, ios)) in data)
            {
                if (androidVersion is not null && iosVersion is not null)
                {
                    return new Tuple<string?, string?>(androidVersion, iosVersion);
                }

                if (android is not null)
                {
                    androidVersion = android.Version;
                }
                if (ios is not null)
                {
                    iosVersion = ios.Version;
                }
            }

            return new Tuple<string?, string?>(androidVersion, iosVersion);
        }

        public static Dictionary<string,Tuple<ModuleData?, ModuleData?>> GetDependencies()
        {
            var json = GetJson();
            var result = new Dictionary<string,Tuple<ModuleData?, ModuleData?>>();
            if (json is null) return result;
            foreach (var (_, value) in json)
            {
                var name = value["name"]?.Value;
                if (name is null) continue;
                var android = GetModule(value["android"]);
                var ios = GetModule(value["ios"]);
                result.Add(name, new Tuple<ModuleData?, ModuleData?>(android, ios));
            }
            return result;
        }

        private static bool HasModule(JSONNode? node)
        {
            if (node == null) return false;
            if (!node.IsObject) return false;
            var json = node.AsObject;
            var module = json["module"]?.Value;
            if (string.IsNullOrWhiteSpace(module)) return false;
            var version = json["version"]?.Value;
            if (string.IsNullOrWhiteSpace(version)) return false;
            return true;
        }
        
        private static ModuleData? GetModule(JSONNode? node)
        {
            if (node == null) return null;
            if (!node.IsObject) return null;
            var json = node.AsObject;
            var module = json["module"]?.Value;
            var version = json["version"]?.Value;
            if (module is null) return null;
            if (version is null) return null;
            return new ModuleData
            {
                Module = module,
                Version = version
            };
        }
    }
}