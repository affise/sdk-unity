#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AffiseAttributionLib.Editor.Modules;
using AffiseAttributionLib.Editor.Utils;
using UnityEditor;
using UnityEngine;

namespace AffiseAttributionLib.Editor.Config
{
    internal class AffiseEditorConfig : ScriptableObject
    {
        [SerializeField] 
        public List<Modules.Module> modules = new();
        
        [SerializeField] 
        public IOSSettings ios = new();
   
        [SerializeField] 
        public bool deeplinksEnabled = false;

        [SerializeField] 
        public List<string?> deeplinks = new();
     
        private static AffiseEditorConfig? _instance;
        public static AffiseEditorConfig? Instance => _instance ??= Load();

        private const string FileFolder = "Assets/Affise/Editor";
        private const string FileAssetName = "AffiseEditorConfig";

        // [MenuItem("Assets/Create/Affise/EditorConfig")] 
        private static AffiseEditorConfig CreateAsset(List<Modules.Module>? modules = null)
        {
            var folder = Directory.CreateDirectory(FileFolder);
            var config = CreateInstance<AffiseEditorConfig>();
            if (modules is not null)
            {
                config.modules = modules;
            }

            AssetDatabase.CreateAsset(config, $"{FileFolder}/{FileAssetName}.asset");
            return config;
        }

        private static string? AssetGuid()
        {
            var guid = AssetDatabase
                .FindAssets(FileAssetName)
                .Select(AssetDatabase.GUIDToAssetPath)
                .FirstOrDefault(x => x.EndsWith($"{FileAssetName}.asset"));

            return guid;
        }

        private static AffiseEditorConfig? Load()
        {
            return AssetDatabase.LoadAssetAtPath<AffiseEditorConfig>(AssetGuid());
        }

        private AffiseEditorConfig CreateOrSaveAsset(List<Modules.Module> newModules)
        {
            if (AssetDatabase.Contains(Instance))
            {
                if (Instance is null) _instance = Load();
                if (Instance is not null) Instance.modules = newModules;
            }
            else
            {
                _instance = CreateAsset(newModules);
            }

            if (Instance is null) return this;
            EditorUtility.SetDirty(Instance);
            AssetDatabase.SaveAssets();
            return this;
        }

        public static void Save(IEnumerable<Modules.Module> modules)
        {
            if (_instance is null) _instance = Load();
            if (_instance is null) return;
            _instance.CreateOrSaveAsset(modules.ToList());
        }
        
        public static void Save()
        {
            if (Instance is null) return;
            EditorUtility.SetDirty(Instance);
            AssetDatabase.SaveAssets();
        }

        private IEnumerable<Modules.Module> UpdatedList()
        {
            var all = ModulesData.Get();
            foreach (var module in all)
            {
                var contains = modules.Any(e => e.name == module.name);
                if (!contains)
                {
                    modules.Add(module);
                }
            }

            return modules;
        }

        public static IEnumerable<Modules.Module> GetModules()
        {
            if (Instance is not null) return Instance.UpdatedList();

            _instance = CreateAsset(ModulesData.Get());

            if (Instance is null) return new List<Modules.Module>();
            EditorUtility.SetDirty(Instance);
            AssetDatabase.SaveAssets();

            return _instance.modules;
        }

        public static Tuple<List<ModuleData>, List<ModuleData>> GetDependencies()
        {
            var resultAndroid = new List<ModuleData>();
            var resultIOS = new List<ModuleData>();

            var modules = GetModules();
            var dependencies = ModulesData.GetDependencies();

            foreach (var module in modules)
            {
                if (!dependencies.ContainsKey(module.name)) continue;
                var dep = dependencies[module.name];
                if (module.android && dep.Item1 is not null)
                {
                    resultAndroid.Add(dep.Item1);
                }

                if (module.ios && dep.Item2 is not null)
                {
                    resultIOS.Add(dep.Item2);
                }
            }

            return new Tuple<List<ModuleData>, List<ModuleData>>(resultAndroid, resultIOS);
        }

        public static Tuple<List<string>, List<string>> GetAllModulesNames()
        {
            var resultAndroid = new List<string>();
            var resultIOS = new List<string>();
            var dependencies = ModulesData.GetDependencies();
            foreach (var (_, (android, ios)) in dependencies)
            {
                if (android is not null)
                {
                    resultAndroid.Add(android.Module);
                }

                if (ios is not null)
                {
                    resultIOS.Add(ios.Module);
                }
            }

            return new Tuple<List<string>, List<string>>(resultAndroid, resultIOS);
        }
    }
}