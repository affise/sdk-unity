#nullable enable
using AffiseAttributionLib.Editor.Utils;
using AffiseAttributionLib.Unity;
using UnityEditor;

namespace AffiseAttributionLib.Editor
{
    internal class AffiseEditorSettings
    {
        public delegate void SettingsChange(AffiseSettings? active);

        public static event SettingsChange? OnChange;

        public static AffiseSettings? Active => Instance.AffiseSettingsInternal;

        public static void Set(AffiseSettings? settings)
        {
            if (Instance.AffiseSettingsInternal == settings) return;
            AssetSettingUtils.SetActive(settings);
            Instance.AffiseSettingsInternal = settings;
            OnChange?.Invoke(settings);
        }

        private AffiseSettings? AffiseSettingsInternal
        {
            get
            {
                EditorBuildSettings.TryGetConfigObject(AffiseSettings.ConfigName, out AffiseSettings? settings);
                return settings;
            }
            set
            {
                if (value is null)
                {
                    EditorBuildSettings.RemoveConfigObject(AffiseSettings.ConfigName);
                }
                else
                {
                    EditorBuildSettings.AddConfigObject(AffiseSettings.ConfigName, value, true);
                }
            }
        }

        private static AffiseEditorSettings? _instance;

        private static AffiseEditorSettings Instance => _instance ??= new AffiseEditorSettings();
    }
}