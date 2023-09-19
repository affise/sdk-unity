#nullable enable
using System;
using AffiseAttributionLib.Editor.Extensions;
using AffiseAttributionLib.Editor.Ui;
using AffiseAttributionLib.Editor.Utils;
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

        #endregion Callback

        #region Unregister Callback

        private void UnbindView()
        {
            if (_settingsNewBtn is not null) _settingsNewBtn.clickable.clicked -= CreateNewSettings;
        }

        private void UnbindDate()
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
        }

        public override void OnDeactivate()
        {
            UnbindDate();
            UnbindView();
            base.OnDeactivate();
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
            _settingsMewMessage = _root.Q<Label>("settings-new-message");
            _settingsMewMessage.text = TextNoSettings;

            _settingsAsset = _root.Q<ObjectField>("settings-asset");
            _settingsAsset.objectType = typeof(AffiseSettings);
            _settingsAsset.label = TextSettings;
            _settingsAsset.tooltip = TextSettingsTooltip;

            _settingsAsset.RegisterValueChangedCallback(OnAssetSelect);

            _settingsNewBtn = _root.Q<Button>("settings-new-btn");
            _settingsNewBtn.clickable.clicked += CreateNewSettings;

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