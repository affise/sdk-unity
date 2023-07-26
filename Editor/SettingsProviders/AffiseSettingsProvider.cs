#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using AffiseAttributionLib.Editor.Extensions;
using AffiseAttributionLib.Editor.Menu;
using AffiseAttributionLib.Editor.Ui;
using AffiseAttributionLib.Editor.Utils;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using UnityObject = UnityEngine.Object;

namespace AffiseAttributionLib.Editor
{
    public class AffiseSettingsProvider : AssetSettingsProvider
    {
        const string WindowPath = "Project/Affise";

        [SettingsProvider]
        private static SettingsProvider CreateProjectSettingsProvider() => new AffiseSettingsProvider();

        private AffiseSettingsProvider() : base(WindowPath, () => AffiseEditorSettings.ActiveSettings)
        {
        }

        private class Text
        {
            public const string k_NoSettingsMsg = "You have no Affise Settings. Would you like to create one?";
            public const string k_ActiveSettings = "Settings";

            public const string k_ActiveSettingsTooltip =
                "Settings that will be used by this project and included into any builds.";
        }

        private VisualElement? _root = null;
        private VisualElement? _settingsNewView = null;
        private VisualElement? _settingsView = null;
        private InspectorElement? _settingsInspector = null;
        private Label? _settingsMewMessage = null;
        private Button? _settingsNewBtn = null;
        private Button? _settingsFindBtn = null;
        private ObjectField? _settingsAsset = null;
        
        private Label? _version = null;
        private Button? _site = null;
        private Button? _email = null;


        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            base.OnActivate(searchContext, rootElement);
            _root = rootElement;

            BindView();
            BindDate(AffiseEditorSettings.ActiveSettings);
        }

        public override void OnDeactivate()
        {
            base.OnDeactivate();
            UnbindDate();
            UnbindView();
        }

        private void BindView()
        {
            _root?.Clear();
            UI.Get(nameof(AffiseSettingsProvider)).ToRoot(_root);

            _version = _root.Q<Label>("version");
            _site = _root.Q<Button>("site");
            _email = _root.Q<Button>("email");

            _settingsNewView = _root.Q<VisualElement>("settings-new-view");
            _settingsView = _root.Q<VisualElement>("setting-view");
            _settingsInspector = _root.Q<InspectorElement>("settings-inspector");
            _settingsMewMessage = _root.Q<Label>("settings-new-message");
            _settingsMewMessage.text = Text.k_NoSettingsMsg;

            _settingsAsset = _root.Q<ObjectField>("settings-asset");
            _settingsAsset.objectType = typeof(AffiseSettings);
            _settingsAsset.label = Text.k_ActiveSettings;
            _settingsAsset.tooltip = Text.k_ActiveSettingsTooltip;

            _settingsAsset.RegisterValueChangedCallback(OnSettingsChange);

            _settingsNewBtn = _root.Q<Button>("settings-new-btn");
            _settingsNewBtn.clickable.clicked += CreateNewSettings;
            _settingsFindBtn = _root.Q<Button>("settings-find");
            _settingsFindBtn.clickable.clicked += FindSettings;

            BindLinks();
        }

        private void UnbindView()
        {
            if (_settingsNewBtn is not null)
            {
                _settingsNewBtn.clickable.clicked -= CreateNewSettings;
            }

            if (_settingsFindBtn is not null)
            {
                _settingsFindBtn.clickable.clicked -= FindSettings;
            }
        }

        private void BindDate(AffiseSettings? settings)
        {
            AffiseEditorSettings.ActiveSettings = settings;
            _settingsAsset?.SetValueWithoutNotify(AffiseEditorSettings.ActiveSettings);
            var hasSettings = settings is not null;
            _settingsNewView?.Hide(hasSettings);
            _settingsView?.Show(hasSettings);

            if (AffiseEditorSettings.ActiveSettings is not null)
            {
                var obj = new SerializedObject(AffiseEditorSettings.ActiveSettings);
                _settingsInspector?.Bind(obj);
            }

            if (_version is not null)
            {
                _version.text = PackageData.GetVersion();
            }
            
            if (_site is not null)
            {
                var url = new Uri(PackageData.GetUrl());
                _site.text = url.Authority;
                _site.tooltip = url.AbsoluteUri;
            }
            
            if (_email is not null)
            {
                var mail = PackageData.GetEmail();
                _email.text = mail;
                _email.tooltip = $"mailto:{mail}";
            }
        }

        private void BindLinks()
        {
            var links = _root.Query<Button>(className: "link").ToList();
            foreach (var link in links)
            {
                link.RegisterCallback<ClickEvent>(_ => { Application.OpenURL(link.tooltip); });
            }
        }

        private void UnbindDate()
        {
            _settingsAsset?.UnregisterValueChangedCallback(OnSettingsChange);
        }

        private void CreateNewSettings()
        {
            var asset = CreateNewSettingsAsset();
            BindDate(asset);
        }

        private AffiseSettings? CreateNewSettingsAsset()
        {
            var created = AffiseSettingsMenuItems.CreateAsset();
            return created;
        }

        private void FindSettings()
        {
            var asset = AssetSettings();
            BindDate(asset);
        }

        private AffiseSettings? AssetSettings()
        {
            if (AffiseEditorSettings.ActiveSettings is not null) return null;
            var assets = Resources.FindObjectsOfTypeAll<AffiseSettings>();
            if (assets is null) return null;
            if (assets.Length == 0) return null;
            var settings = new List<AffiseSettings>();
            foreach (var affiseSettings in assets)
            {
                var path = AssetDatabase.GetAssetPath(affiseSettings);
                var name = Path.GetFileNameWithoutExtension(path);
                if (!name.Equals(AffiseSettings.DefaultName)) continue;
                settings.Add(affiseSettings);
            }
            if (settings.Count == 0) return null;
            if (settings.Count == 1) return settings[0];
            Debug.LogWarning(
                "Too many Affise Settings found in project. Please leave only one. With name \"Affise Settings\"");

            var i = 1;
            foreach (var affiseSettings in settings)
            {
                var path = AssetDatabase.GetAssetPath(affiseSettings);
                Debug.LogWarning($"{i}: {path}");
                i++;
            }
            Debug.LogWarning($"Using settings: {AssetDatabase.GetAssetPath(settings[0])}");
            return settings[0];
        }

        private void OnSettingsChange(ChangeEvent<UnityObject> e)
        {
            BindDate(e.newValue as AffiseSettings);
        }
    }
}