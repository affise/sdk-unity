using AffiseAttributionLib.Editor.Extensions;
using AffiseAttributionLib.Editor.Menu;
using AffiseAttributionLib.Editor.Ui;
using UnityEditor;
using UnityEditor.UIElements;
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
            public const string k_NoSettingsMsg = "You have no active settings. Would you like to create one?";
            public const string k_ActiveSettings = "Affise Settings";

            public const string k_ActiveSettingsTooltip =
                "Settings that will be used by this project and included into any builds.";
        }

        private VisualElement _root;
        private VisualElement _settingsView;
        private VisualElement _settingsNewView;
        private InspectorElement _settingsInspector;
        private Label _settingsInfo;
        private Button _settingsCreateBtn;
        private ObjectField _settingsField;

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            base.OnActivate(searchContext, rootElement);
            _root = rootElement;
            InitView();
        }

        public override void OnDeactivate()
        {
            base.OnDeactivate();
            UnbindDate();
            UnbindView();
        }

        private void InitView()
        {
            _root.Clear();
            UI.Get(nameof(AffiseSettingsProvider)).ToRoot(_root);

            BindView();
            BindDate();
        }

        private void BindView()
        {
            _settingsView = _root.Q<VisualElement>("settings");
            _settingsNewView = _root.Q<VisualElement>("settings-new");
            _settingsInspector = _root.Q<InspectorElement>("settings-inspector");
            _settingsInfo = _root.Q<Label>("settings-info");
            _settingsInfo.text = Text.k_NoSettingsMsg;

            _settingsField = _root.Q<ObjectField>("settings-field");
            _settingsField.objectType = typeof(AffiseSettings);
            _settingsField.label = Text.k_ActiveSettings;
            _settingsField.tooltip = Text.k_ActiveSettingsTooltip;
            _settingsField.SetValueWithoutNotify(AffiseEditorSettings.ActiveSettings);
            _settingsField.RegisterValueChangedCallback(OnSettingsChange);

            _settingsCreateBtn = _root.Q<Button>("settings-create");
            _settingsCreateBtn.clickable.clicked += SettingsCreate;
        }

        private void UnbindView()
        {
            if (_settingsCreateBtn != null)
            {
                _settingsCreateBtn.clickable.clicked -= SettingsCreate;
            }
        }

        private void BindDate()
        {
            var isActive = AffiseEditorSettings.ActiveSettings != null;

            _settingsNewView.Gone(isActive);
            _settingsView.Gone(!isActive);

            if (AffiseEditorSettings.ActiveSettings is null) return;
            var obj = new SerializedObject(AffiseEditorSettings.ActiveSettings);
            _settingsInspector.Bind(obj);
        }

        private void UnbindDate()
        {
            _settingsField?.UnregisterValueChangedCallback(OnSettingsChange);
        }

        private void SettingsCreate()
        {
            var created = AffiseSettingsMenuItems.CreateAsset();
            if (created == null) return;

            AffiseEditorSettings.ActiveSettings = created;

            InitView();
        }

        private void OnSettingsChange(ChangeEvent<UnityObject> e)
        {
            AffiseEditorSettings.ActiveSettings = e.newValue as AffiseSettings;
            BindDate();
        }
    }
}