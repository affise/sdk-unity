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
        private Dictionary<ToolbarToggle, VisualElement> _tabs = new();
        private ModuleList? _moduleList;
        private TextField? _iosNsUserTracking;
        private ListView? _deepLinks;
        private Toggle? _deeplinkToggle;

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

        private void OnTextFieldChange(ChangeEvent<string> evt)
        {
            if (evt.previousValue == evt.newValue) return;
            if (evt.target == _iosNsUserTracking)
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
            if (evt.newValue == true)
            {
                _current = evt.target as ToolbarToggle;
            }

            foreach (var (tab, view) in _tabs)
            {
                tab.value = _current == tab;
                view.Show(_current == tab);
            }
        }

        private void OnModuleChange(ChangeEvent<IEnumerable<Modules.Module>> evt)
        {
            AffiseEditorConfig.Save(evt.newValue);
        }

        private void OnToggleChange(ChangeEvent<bool> evt)
        {
            if (evt.previousValue == evt.newValue) return;
            if (evt.target == _deeplinkToggle)
            {
                if (AffiseEditorConfig.Instance is not null)
                {
                    AffiseEditorConfig.Instance.deeplinksEnabled = evt.newValue;
                    AffiseEditorConfig.Save();
                }
            }
        }

        #endregion Callback

        #region Unregister Callback

        private void UnbindView()
        {
            TabUnregister();

            _moduleList?.UnregisterValueChangedCallback(OnModuleChange);
            _iosNsUserTracking?.UnregisterValueChangedCallback(OnTextFieldChange);
            _deeplinkToggle?.UnregisterValueChangedCallback(OnToggleChange);
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

            _deeplinkToggle = _root.Q<Toggle>("deeplink-toggle");
            if (AffiseEditorConfig.Instance is not null)
            {
                _deeplinkToggle.value = AffiseEditorConfig.Instance.deeplinksEnabled;
            }

            _deeplinkToggle?.RegisterValueChangedCallback(OnToggleChange);

            var deeplink = _root.Q<Foldout>("deeplink");
            DeeplinkList(deeplink);

            TabInit();
            TabAdd("tab1", "tab-view1");
            TabAdd("tab2", "tab-view2");
            TabAdd("tab3", "tab-view3");
            TabDefault(0);

            _moduleList = new ModuleList(AffiseEditorConfig.GetModules(), ModulesData.GetModulesComment());
            _moduleList?.RegisterValueChangedCallback(OnModuleChange);

            var modulesView = _root.Q<Foldout>("modules-view");
            modulesView.Add(_moduleList);

            _iosNsUserTracking = _root.Q<TextField>("NSUserTrackingUsageDescription-Edit");
            if (AffiseEditorConfig.Instance is not null)
            {
                _iosNsUserTracking.value = AffiseEditorConfig.Instance.ios.nsUserTrackingUsageDescription;
            }

            _iosNsUserTracking?.RegisterValueChangedCallback(OnTextFieldChange);

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

        #region Tabs

        private void TabInit()
        {
            _tabs = new Dictionary<ToolbarToggle, VisualElement>();
        }

        private void TabAdd(string tabName, string viewName)
        {
            var tab = _root.Q<ToolbarToggle>(tabName);
            if (tab is null) return;
            var view = _root.Q<VisualElement>(viewName);
            if (view is null) return;
            tab.RegisterValueChangedCallback(OnTabChange);
            _tabs.Add(tab, view);
        }

        private void TabUnregister()
        {
            foreach (var (tab, _) in _tabs)
            {
                tab.UnregisterValueChangedCallback(OnTabChange);
            }
        }

        private void TabDefault(int index = 0)
        {
            var idx = -1;
            foreach (var (tab, view) in _tabs)
            {
                idx++;
                if (idx != index) continue;
                var evt = ChangeEvent<bool>.GetPooled(false, true);
                evt.target = tab;
                OnTabChange(evt);
                return;
            }
        }

        #endregion Tabs

        #region ListView

        private void DeeplinkList(VisualElement container)
        {
            if (AffiseEditorConfig.Instance is null) return;

            Func<VisualElement> makeItem = () =>
            {
                var item = new VisualElement()
                {
                    style =
                    {
                        flexDirection = FlexDirection.Row,
                    }
                };
                var textField = new TextField()
                {
                    style =
                    {
                        flexGrow = 1,
                    }
                };
                textField.RegisterValueChangedCallback(OnListItemChange);
                item.Add(textField);
                item.AddToClassList("list-item");
                return item;
            };

            Action<VisualElement, int> bindItem = (elm, index) =>
            {
                var field = elm.Q<TextField>();

                if (field is null) return;
                field.value = AffiseEditorConfig.Instance.deeplinks[index];
                field.name = $"{index}";
            };

            _deepLinks = container.Q<ListView>();
            _deepLinks.makeItem = makeItem;
            _deepLinks.bindItem = bindItem;
            _deepLinks.itemsSource = AffiseEditorConfig.Instance.deeplinks;
            _deepLinks.selectionType = SelectionType.Multiple;

            _deepLinks.itemsRemoved += e => { AffiseEditorConfig.Save(); };
        }

        private void OnListItemChange(ChangeEvent<string> evt)
        {
            var name = (evt.target as TextField)?.name;
            if (name is null) return;
            if (int.TryParse(name, out var index) == false) return;
            if (AffiseEditorConfig.Instance is null) return;

            AffiseEditorConfig.Instance.deeplinks[index] = evt.newValue;
            AffiseEditorConfig.Save();
        }

        #endregion ListView
    }
}