using AffiseAttributionLib.Init;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AffiseAttributionLib
{
    public class AffiseSettings : ScriptableObject
    {
        internal const string ConfigName = "affise.settings";
        public const string DefaultName = "Affise Settings";

        #region Variables

        [SerializeField]
        private string appId = "";

        [SerializeField]
        private string partParamName = "";

        [SerializeField]
        private string partParamNameToken = "";

        [SerializeField]
        private string appToken = "";

        [SerializeField]
        private string secretId = "";

        [SerializeField]
        private bool isProduction = true;

        [HideInInspector]
        [SerializeField]
        public AffiseBuildInfo buildInfo;

        #endregion Variables

        #region Init settings

        private void OnEnable()
        {
            _instance ??= this;
        }

        private static AffiseSettings _instance;

        public static AffiseSettings Instance
        {
            get => _instance ? _instance : (_instance = GetOrCreateSettings());
            set => _instance = value;
        }

        private static AffiseSettings GetInstanceDontCreateDefault()
        {
            if (_instance is not null) return _instance;

            AffiseSettings settings;
#if UNITY_EDITOR
            EditorBuildSettings.TryGetConfigObject(ConfigName, out settings);
#else
            LoadFromResources(out settings);
#endif
            return settings;
        }

        private static void LoadFromResources(out AffiseSettings settings)
        {
            settings = Resources.Load<AffiseSettings>(DefaultName);
            if (settings is null) return;
            
            var allSettings = Resources.FindObjectsOfTypeAll<AffiseSettings>();
            foreach (var affiseSettings in allSettings)
            {
                settings = affiseSettings;
                return;
            }
        }

        static AffiseSettings GetOrCreateSettings()
        {
            var settings = GetInstanceDontCreateDefault();
            if (settings is not null) return settings;

            Debug.LogWarning("Could not find affise settings. Default will be used.");

            settings = CreateInstance<AffiseSettings>();
            settings.name = $"Default {DefaultName}";

            return settings;
        }

        #endregion Init settings

        #region Init Affise

        // Load Affise after level starts
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static void OnSceneLoadInitialize()
        {
            Instance.Init();
        }

        private void Init()
        {
            if (Affise.IsInit) return;

            var props = new AffiseInitProperties(
                appId,
                partParamName,
                partParamNameToken,
                appToken,
                secretId,
                isProduction,
                buildInfo
            );

            Affise.Init(props);
        }

        #endregion Init Affise
    }
}