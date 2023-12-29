using AffiseAttributionLib.Editor.Config;
using AffiseAttributionLib.Editor.SettingsProviders;
using UnityEditor;
using UnityEngine.UIElements;

namespace AffiseAttributionLib.Editor.Ui.Editors
{
    [CustomEditor(typeof(AffiseEditorConfig), true)]
    internal class AffiseEditorConfigEditor : UnityEditor.Editor
    {
        private VisualElement _root;

        public override VisualElement CreateInspectorGUI()
        {
            _root = new VisualElement();

            var button = new Button(OnSettingsButton)
            {
                text = "Open Affise Settings Tab",
            };
            _root.Add(button);
            _root.Add(new Label("This file should be located in Editor folder"));
            _root.Add(new Label("This file will not be included in build"));

            return _root;
        }

        private void OnSettingsButton()
        {
            SettingsService.OpenProjectSettings(AffiseSettingsProvider.WindowPath);
        }
    }
}