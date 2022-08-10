using AffiseAttributionLib.Editor.Extensions;
using AffiseAttributionLib.Editor.Ui;
using AffiseAttributionLib;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CanEditMultipleObjects]
[CustomEditor(typeof(AffiseSettings), true)]
public class AffiseSettingsEditor : Editor
{
    private VisualElement _root;
    private SerializedProperty _appId;
    private SerializedProperty _partParamName;
    private SerializedProperty _partParamNameToken;
    private SerializedProperty _appToken;
    private SerializedProperty _isProduction;
    private SerializedProperty _secretId;

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

    private void BindView()
    {
        var appIdField = _root.Q<TextField>("appId");
        var partParamNameField = _root.Q<TextField>("partParamName");
        var partParamNameTokenField = _root.Q<TextField>("partParamNameToken");
        var appTokenField = _root.Q<TextField>("appToken");
        var isProductionField = _root.Q<Toggle>("isProduction");
        var secretIdField = _root.Q<TextField>("secretId");

        appIdField.BindProperty(_appId);
        partParamNameField.BindProperty(_partParamName);
        partParamNameTokenField.BindProperty(_partParamNameToken);
        appTokenField.BindProperty(_appToken);
        isProductionField.BindProperty(_isProduction);
        secretIdField.BindProperty(_secretId);
    }
}