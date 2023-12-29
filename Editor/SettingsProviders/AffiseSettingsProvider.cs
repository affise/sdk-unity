#nullable enable
using System;
using System.Collections.Generic;
using AffiseAttributionLib.Editor.Config;
using AffiseAttributionLib.Editor.Elements;
using AffiseAttributionLib.Editor.Extensions;
using AffiseAttributionLib.Editor.Ui;
using AffiseAttributionLib.Editor.Utils;
using AffiseAttributionLib.Unity;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using UnityObject = UnityEngine.Object;

namespace AffiseAttributionLib.Editor.SettingsProviders
{
    internal class AffiseSettingsProvider : AssetSettingsProvider
    {
        #region UI const

        internal const string WindowPath = "Project/Affise";
        private const string TextNoSettings = "You have no active Affise Settings. Would you like to create one?";
        private const string TextSettings = "Settings";

        private const string TextSettingsTooltip =
            "Settings that will be used by this project and included into any builds.";

        #endregion UI const

        #region UI Variables

        private VisualElement? _root;
        
        private ToolbarToggle? _current;
        private ToolbarToggle? _tab1;
        private ToolbarToggle? _tab2;
        private VisualElement? _tabView1;
        private VisualElement? _tabView2;
        private ModuleList? _moduleList;        
        private TextField? _iosNSUserTracking;
        
        private VisualElement? _settingsNewView;
        private VisualElement? _settingsView;
        private VisualElement? _inspectorView;
        private Label? _settingsMewMessage;
        private Button? _settingsNewBtn;
        private ObjectField? _settingsAsset;

        private Label? _version;
        private Button? _site;
        private Button? _email;

        #endregion UI Variables

        #region Instance

        [SettingsProvider]
        private static SettingsProvider CreateProjectSettingsProvider() => new AffiseSettingsProvider();

        private AffiseSettingsProvider() : base(WindowPath, () => AffiseEditorSettings.Active)
        {
        }

        #endregion Instance

        private void BindAssetWithoutNotify(AffiseSettings? settings)
        {
            _settingsAsset?.SetValueWithoutNotify(settings);
        }

        private void BindInspector(AffiseSettings? settings)
        {
            if (_inspectorView is null) return;
            _inspectorView.Clear();
            if (settings is null) return;

            _inspectorView.Add(new InspectorElement(settings));
        }

        #region Callback

        private void OnSettingsChange(AffiseSettings? active)
        {
            SettingsModeView(active);
            BindAssetWithoutNotify(active);
            BindInspector(active);
        }

        private void OnAssetSelect(ChangeEvent<UnityObject> evt)
        {
            AffiseEditorSettings.Set(evt.newValue as AffiseSettings);
        }
        
        private void OnTextFieldChnabge(ChangeEvent<string> evt)
        {
            if (evt.previousValue == evt.newValue) return;
            if (evt.target == _iosNSUserTracking)
            {
                if (AffiseEditorConfig.Instance is not null)
                {
                    AffiseEditorConfig.Instance.ios.nsUserTrackingUsageDescription = evt.newValue ?? "";
                    AffiseEditorConfig.Save();
                }
            }
        }
        
        private void OnTabChange(ChangeEvent<bool> evt)
        {
            if (_tab1 is null || _tab2 is null) return;
            if (_tabView1 is null || _tabView2 is null) return;

            if (evt.newValue == true)
            {
                _current = evt.target as ToolbarToggle;
            }
            
            if (_current == _tab1)
            {
                _tab1.value = true;
                _tab2.value = false;
                _tabView1.Show();
                _tabView2.Hide();
            } else if (_current == _tab2)
            {
                _tab1.value = false;
                _tab2.value = true;
                _tabView1.Hide();
                _tabView2.Show();
            }
        }
        
        private void OnModuleChange(ChangeEvent<IEnumerable<Modules.Module>> evt)
        {
            AffiseEditorConfig.Save(evt.newValue);
        }

        #endregion Callback

        #region Unregister Callback

        private void UnbindView()
        {
            _tab1?.UnregisterValueChangedCallback(OnTabChange);
            _tab2?.UnregisterValueChangedCallback(OnTabChange);
            _moduleList?.UnregisterValueChangedCallback(OnModuleChange);
            _iosNSUserTracking?.UnregisterValueChangedCallback(OnTextFieldChnabge);
            if (_settingsNewBtn is not null) _settingsNewBtn.clickable.clicked -= CreateNewSettings;
        }

        private void UnbindData()
        {
            AffiseEditorSettings.OnChange -= OnSettingsChange;
            _settingsAsset?.UnregisterValueChangedCallback(OnAssetSelect);
        }

        #endregion Unregister Callback

        #region AffiseSetting.asset

        private void CreateNewSettings()
        {
            AffiseEditorSettings.Set(AssetSettingUtils.Create());
        }

        #endregion AffiseSetting.asset

        #region UI Metadata

        private void SetMetadata()
        {
            SetVersion(PackageData.GetVersion());
            SetSite(PackageData.GetUrl());
            SetMail(PackageData.GetEmail());
        }

        private void SetVersion(string version)
        {
            if (_version is null) return;
            _version.text = version;
        }

        private void SetSite(string link)
        {
            if (_site is null) return;
            var url = new Uri(link);
            _site.text = url.Authority;
            _site.tooltip = url.AbsoluteUri;
        }

        private void SetMail(string mail)
        {
            if (_email is null) return;
            _email.text = mail;
            _email.tooltip = $"mailto:{mail}";
        }

        #endregion UI Metadata

        #region UI setup

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            base.OnActivate(searchContext, rootElement);
            _root = rootElement;

            BindView();
            BindData();

            if (_tab1 is not null)
            {
                _tab1.value = true;
            }
        }

        public override void OnDeactivate()
        {
            UnbindData();
            UnbindView();
            base.OnDeactivate();
        }

        private void BindView()
        {
            _root?.Clear();
            UI.Get(nameof(AffiseSettingsProvider)).ToRoot(_root);
            if (_root is null) return;

            _version = _root.Q<Label>("version");
            _site = _root.Q<Button>("site");
            _email = _root.Q<Button>("email");

            _tab1 = _root.Q<ToolbarToggle>("tab1");
            _tab2 = _root.Q<ToolbarToggle>("tab2");
            
            _tab1?.RegisterValueChangedCallback(OnTabChange);
            _tab2?.RegisterValueChangedCallback(OnTabChange);
            
            _tabView1 = _root.Q<VisualElement>("tab-view1");
            _tabView2 = _root.Q<VisualElement>("tab-view2");

            _moduleList = new ModuleList(AffiseEditorConfig.GetModules());
            _moduleList?.RegisterValueChangedCallback(OnModuleChange);
            
            var modulesView = _root.Q<Foldout>("modules-view");
            modulesView.Add(_moduleList);
            
            _iosNSUserTracking = _root.Q<TextField>("NSUserTrackingUsageDescription-Edit");
            if (AffiseEditorConfig.Instance is not null)
            {
                _iosNSUserTracking.value = AffiseEditorConfig.Instance.ios.nsUserTrackingUsageDescription;
            }
            _iosNSUserTracking?.RegisterValueChangedCallback(OnTextFieldChnabge);


            _settingsNewView = _root.Q<VisualElement>("settings-new-view");
            _settingsView = _root.Q<VisualElement>("setting-view");
            _settingsMewMessage = _root.Q<Label>("settings-new-message");
            if (_settingsMewMessage is not null)
            {
                _settingsMewMessage.text = TextNoSettings;
            }

            _settingsAsset = _root.Q<ObjectField>("settings-asset");
            if (_settingsAsset is not null)
            {
                _settingsAsset.objectType = typeof(AffiseSettings);
                _settingsAsset.label = TextSettings;
                _settingsAsset.tooltip = TextSettingsTooltip;
                _settingsAsset.RegisterValueChangedCallback(OnAssetSelect);
            }

            _settingsNewBtn = _root.Q<Button>("settings-new-btn");
            if (_settingsNewBtn is not null)
            {
                _settingsNewBtn.clickable.clicked += CreateNewSettings;
            }

            _inspectorView = _root.Q<VisualElement>("inspector-view");
        }

        private void BindData()
        {
            BindLinks();
            SetMetadata();

            AffiseEditorSettings.OnChange += OnSettingsChange;
            OnSettingsChange(AffiseEditorSettings.Active);
        }

        private void BindLinks()
        {
            var links = _root.Query<Button>(className: "link").ToList();
            foreach (var link in links)
            {
                link.RegisterCallback<ClickEvent>(_ => { Application.OpenURL(link.tooltip); });
            }
        }

        #endregion setup

        private void SettingsModeView(AffiseSettings? settings)
        {
            var hasSettings = settings is not null;
            _settingsNewView?.Hide(hasSettings);
            _settingsView?.Show(hasSettings);
        }
    }
}