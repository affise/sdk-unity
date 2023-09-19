#nullable enable
using System.Text.RegularExpressions;
using AffiseAttributionLib.Editor.Extensions;
using AffiseAttributionLib.Editor.SettingsProviders;
using AffiseAttributionLib.Editor.Utils;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AffiseAttributionLib.Editor.Ui.Editors
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(AffiseSettings), true)]
    internal class AffiseSettingsEditor : UnityEditor.Editor
    {
        #region UI const

        private const string TextActive = "Press To Set As Active Setting";
        private const string TextNotActive = "This Is Active settings";

        private const string WrongFolder =
            "Asset must be placed in \"Resources\" folder:\n<any_folder>/Resources/<your_affise_settings>.asset";

        private const string AppIdEmpty = "Application ID not set";
        private const string SecretKeyEmpty = "Secret Key not set";

        #endregion UI const

        #region UI Variables

        private VisualElement? _root;
        private Button? _settingsBtn;
        private SerializedProperty? _appId;
        private SerializedProperty? _secretId;
        private SerializedProperty? _partParamName;
        private SerializedProperty? _partParamNameToken;
        private SerializedProperty? _appToken;
        private SerializedProperty? _isProduction;
        private SerializedProperty? _isActive;

        private VisualElement? _warningView;
        private Label? _warning;
        private Button? _setActive;
        private VisualElement? _infoActive;

        private TextField? _appIdField;
        private TextField? _secretIdField;
        private Toggle? _isActiveToggle;

        private AffiseSettings? _settings;

        #endregion UI Variables

        #region UI Bind

        private void UnBindView()
        {
            AffiseEditorSettings.OnChange -= OnSettingsChange;

            _appIdField.UnregisterValueChangedCallback(OnTextChange);
            _secretIdField.UnregisterValueChangedCallback(OnTextChange);
            
            _appIdField?.UnregisterCallback<KeyDownEvent>(OnKeyDown);
            _secretIdField?.UnregisterCallback<KeyDownEvent>(OnKeyDown);

            if (_settingsBtn is not null) _settingsBtn.clickable.clicked -= OnSettingsButton;
            if (_setActive is not null) _setActive.clickable.clicked -= OnSetActiveButton;
        }

        private void BindView()
        {
            _warningView = _root.Q<VisualElement>("warning-asset");
            _warning = _root.Q<Label>("warning-text");

            _appIdField = _root.Q<TextField>("appId");
            _secretIdField = _root.Q<TextField>("secretId");
            _isActiveToggle = _root.Q<Toggle>("isActive");

            var partParamNameField = _root.Q<TextField>("partParamName");
            var partParamNameTokenField = _root.Q<TextField>("partParamNameToken");
            var appTokenField = _root.Q<TextField>("appToken");
            var isProductionField = _root.Q<Toggle>("isProduction");

            _settingsBtn = _root.Q<Button>("OpenSettings");
            _settingsBtn.clickable.clicked += OnSettingsButton;

            _infoActive = _root.Q<VisualElement>("notActive");
            _setActive = _root.Q<Button>("setActive");
            _setActive.clickable.clicked += OnSetActiveButton;

            _appIdField?.BindProperty(_appId);
            _secretIdField?.BindProperty(_secretId);
            partParamNameField?.BindProperty(_partParamName);
            partParamNameTokenField?.BindProperty(_partParamNameToken);
            appTokenField?.BindProperty(_appToken);
            isProductionField?.BindProperty(_isProduction);
            _isActiveToggle?.BindProperty(_isActive);

            if (_appIdField is not null) _appIdField.isDelayed = true;
            if (_secretIdField is not null) _secretIdField.isDelayed = true;
            
            _appIdField.RegisterValueChangedCallback(OnTextChange);
            _secretIdField.RegisterValueChangedCallback(OnTextChange);
            _isActiveToggle.RegisterValueChangedCallback(OnActiveSettingsChange);
            
            _appIdField?.RegisterCallback<KeyDownEvent>(OnKeyDown);
            _secretIdField?.RegisterCallback<KeyDownEvent>(OnKeyDown);

            AffiseEditorSettings.OnChange += OnSettingsChange;
        }

        private void BindData()
        {
            _settings = target as AffiseSettings;
            UpdateOnActive(_isActive?.boolValue ?? false);
            if (_setActive != null) _setActive.text = TextActive;
            _infoActive.Q<Label>("activeLabel").text = TextNotActive;
        }

        #endregion UI Bind

        private void UpdateOnActive(bool active)
        {
            _setActive?.Hide(active);
            _infoActive?.Show(active);
        }

        #region Warnings

        private string? CheckAssetWarning()
        {
            if (AssetSettingUtils.CheckFolder(_settings)) return null;

            return WrongFolder;
        }

        private string? CheckFieldsWarning()
        {
            if (string.IsNullOrEmpty(_appId?.stringValue)) return AppIdEmpty;
            if (string.IsNullOrEmpty(_secretId?.stringValue)) return SecretKeyEmpty;
            return null;
        }

        private string? CheckValidSymbols(string text)
        {
            var m = Regex.Match(text, "([^0-9a-f-])", RegexOptions.IgnoreCase);
            if (!m.Success) return null;
            var start = m.Index - 1;
            var length = 3;
            if (start < 0) start = 0;
            if (length + start > text.Length) length = text.Length - start;
            if (length < 0) length = 0;
            
            return $"Symbol '{m.Value}' not allowed in '{text.Substring(start, length)}'";
        }

        private void ShowWarning(string? warningText)
        {
            _warningView.Hide();
            if (_warning is null) return;
            if (string.IsNullOrEmpty(warningText)) return;
            _warning.text = warningText;
            _warningView.Show();
        }

        #endregion Warnings

        #region Callback

        private void OnSettingsChange(AffiseSettings? active)
        {
            if (_isActiveToggle is null) return;
            var same = _settings == active;
            var isActive = (active is not null) && active.isActive;

            if (same)
            {
                _isActiveToggle.SetValueWithoutNotify(isActive);
                UpdateOnActive(isActive);
            }
            else
            {
                _isActiveToggle.SetValueWithoutNotify(false);
                UpdateOnActive(false);
            }
        }

        private void OnActiveSettingsChange(ChangeEvent<bool> evt)
        {
            if (evt.previousValue == evt.newValue) return;
            var same = AffiseEditorSettings.Active == _settings;
            ShowWarning(CheckAssetWarning());
            var active = (evt.newValue) ? _settings : AffiseEditorSettings.Active;
            if (same && evt.newValue == false)
            {
                active = null;
            }

            UpdateOnActive(_settings == active);
            AffiseEditorSettings.Set(active);
        }

        private void OnTextChange(ChangeEvent<string> evt)
        {
            if (evt.newValue.StartsWith(' ') || evt.newValue.EndsWith(' '))
            {
                evt.PreventDefault();
                if (evt.target is TextField textField)
                {
                    textField.value = evt.newValue.Trim();
                }
                return;
            }

            var warning = CheckFieldsWarning();
            if (evt.target == _secretIdField)
            {
                warning ??= CheckValidSymbols(evt.newValue);
            }
            warning ??= CheckAssetWarning();
            ShowWarning(warning);
        }

        private void OnKeyDown(KeyDownEvent evt)
        {
            if (evt.character != ' ') return;
            evt.PreventDefault();
        }

        private void OnSettingsButton()
        {
            SettingsService.OpenProjectSettings(AffiseSettingsProvider.WindowPath);
        }

        private void OnSetActiveButton()
        {
            if (_settings is null) return;
            _settings.isActive = true;
        }

        #endregion Callback

        #region UI setup

        private void FindAllProperties()
        {
            _appId = serializedObject.FindProperty("appId");
            _partParamName = serializedObject.FindProperty("partParamName");
            _partParamNameToken = serializedObject.FindProperty("partParamNameToken");
            _appToken = serializedObject.FindProperty("appToken");
            _isProduction = serializedObject.FindProperty("isProduction");
            _secretId = serializedObject.FindProperty("secretId");
            _isActive = serializedObject.FindProperty("isActive");
        }

        public override VisualElement CreateInspectorGUI()
        {
            FindAllProperties();

            _root = new VisualElement();
            UI.Get(nameof(AffiseSettingsEditor)).ToRoot(_root);
            BindView();
            BindData();
            return _root;
        }

        private void OnDestroy()
        {
            UnBindView();
        }

        #endregion UI setup
    }
}