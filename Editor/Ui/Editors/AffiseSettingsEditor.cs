#nullable enable
using System.IO;
using AffiseAttributionLib;
using AffiseAttributionLib.Editor.Extensions;
using AffiseAttributionLib.Editor.Ui;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CanEditMultipleObjects]
[CustomEditor(typeof(AffiseSettings), true)]
public class AffiseSettingsEditor : Editor
{
    private VisualElement? _root;
    private Button? _settingsBtn;
    private SerializedProperty? _appId;
    private SerializedProperty? _secretId;
    private SerializedProperty? _partParamName;
    private SerializedProperty? _partParamNameToken;
    private SerializedProperty? _appToken;
    private SerializedProperty? _isProduction;

    private VisualElement? _warningView;
    private Label? _warning;

    private TextField? _appIdField;
    private TextField? _secretIdField;

    private const string AppIdEmpty = "Application ID not set";
    private const string SecretKeyEmpty = "Secret Key not set";

    private void FindAllProperties()
    {
        _appId = serializedObject.FindProperty("appId");
        _partParamName = serializedObject.FindProperty("partParamName");
        _partParamNameToken = serializedObject.FindProperty("partParamNameToken");
        _appToken = serializedObject.FindProperty("appToken");
        _isProduction = serializedObject.FindProperty("isProduction");
        _secretId = serializedObject.FindProperty("secretId");
    }

    public override VisualElement CreateInspectorGUI()
    {
        FindAllProperties();

        _root = new VisualElement();
        UI.Get(nameof(AffiseSettingsEditor)).ToRoot(_root);
        BindView();
        return _root;
    }

    private string? GetAssetPath()
    {
        return AssetDatabase.GetAssetPath(target);
    }

    private string? GetAssetFieName(string assetPath)
    {
        return Path.GetFileNameWithoutExtension(assetPath);
    }

    private bool IsValidAsset(string? assetPath)
    {
        if (assetPath is null) return false;
        return assetPath.EndsWith($"Resources/{AffiseSettings.DefaultName}.asset");
    }

    private void OnDestroy()
    {
        UnBindView();
    }

    private void UnBindView()
    {
        _appIdField.UnregisterValueChangedCallback(OnTextChange);
        _secretIdField.UnregisterValueChangedCallback(OnTextChange);

        if (_settingsBtn is null) return;
        _settingsBtn.clickable.clicked -= OnSettingsButton;
    }

    private void BindView()
    {
        _warningView = _root.Q<VisualElement>("warning-asset");
        _warning = _root.Q<Label>("warning-text");

        _appIdField = _root.Q<TextField>("appId");
        _secretIdField = _root.Q<TextField>("secretId");

        var partParamNameField = _root.Q<TextField>("partParamName");
        var partParamNameTokenField = _root.Q<TextField>("partParamNameToken");
        var appTokenField = _root.Q<TextField>("appToken");
        var isProductionField = _root.Q<Toggle>("isProduction");

        _settingsBtn = _root.Q<Button>("OpenSettings");
        _settingsBtn.clickable.clicked += OnSettingsButton;

        _appIdField?.BindProperty(_appId);
        _secretIdField?.BindProperty(_secretId);
        partParamNameField?.BindProperty(_partParamName);
        partParamNameTokenField?.BindProperty(_partParamNameToken);
        appTokenField?.BindProperty(_appToken);
        isProductionField?.BindProperty(_isProduction);

        _appIdField.RegisterValueChangedCallback(OnTextChange);
        _secretIdField.RegisterValueChangedCallback(OnTextChange);
    }


    private void OnTextChange(ChangeEvent<string> e)
    {
        if (!string.IsNullOrWhiteSpace(e.newValue))
        {
            var warning = CheckFieldsWarning() ?? CheckAssetWarning();
            ShowWarning(warning);
            return;
        }

        if (e.target == _appIdField)
        {
            ShowWarning(AppIdEmpty);
        }

        if (e.target == _secretIdField)
        {
            ShowWarning(SecretKeyEmpty);
        }
    }

    private string? CheckAssetWarning()
    {
        var path = GetAssetPath();
        if (path is null) return "AssetPath not found";
        if (IsValidAsset(path)) return null;
        var assetName = GetAssetFieName(path);
        if (assetName is null) return "AssetFieName undefined";

        var warningText = "";
        if (!assetName.Equals(AffiseSettings.DefaultName))
        {
            warningText = $"Asset name must be: \"{AffiseSettings.DefaultName}.asset\"";
        }
        else if (!path.EndsWith($"Resources/{AffiseSettings.DefaultName}.asset"))
        {
            warningText =
                $"Asset must be placed in \"Resources\" folder: \"<any folder>/Resources/{AffiseSettings.DefaultName}.asset\"";
        }

        return warningText;
    }

    private string? CheckFieldsWarning()
    {
        if (string.IsNullOrEmpty(_appId?.stringValue)) return AppIdEmpty;
        if (string.IsNullOrEmpty(_secretId?.stringValue)) return SecretKeyEmpty;
        return null;
    }

    private void ShowWarning(string? warningText)
    {
        _warningView.Hide();
        if (_warning is null) return;
        if (string.IsNullOrEmpty(warningText)) return;
        _warning.text = warningText;
        _warningView.Show();
    }

    private void OnSettingsButton()
    {
        SettingsService.OpenProjectSettings("Project/Affise");
    }
}