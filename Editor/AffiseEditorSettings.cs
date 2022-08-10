using UnityEditor;

namespace AffiseAttributionLib.Editor
{
    public class AffiseEditorSettings
    {
        private static AffiseEditorSettings _instance;

        internal static AffiseEditorSettings Instance
        {
            get => _instance ??= new AffiseEditorSettings();
            set => _instance = value;
        }

        public static AffiseSettings ActiveSettings
        {
            get => Instance.AffiseSettingsInternal;
            set => Instance.AffiseSettingsInternal = value;
        }

        protected virtual AffiseSettings AffiseSettingsInternal
        {
            get
            {
                EditorBuildSettings.TryGetConfigObject(AffiseSettings.ConfigName, out AffiseSettings settings);
                return settings;
            }
            set
            {
                if (value == null)
                {
                    EditorBuildSettings.RemoveConfigObject(AffiseSettings.ConfigName);
                }
                else
                {
                    EditorBuildSettings.AddConfigObject(AffiseSettings.ConfigName, value, true);
                }
            }
        }
    }
}