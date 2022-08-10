using System;
using System.Collections;
using UnityEngine;

namespace AffiseAttributionLib
{
    internal class AffiseWorker : MonoBehaviour
    {
        #region Application events
        public static event Action OnStart = delegate { };
        public static event Action OnQuit = delegate { };
        public static event Action<bool> OnPause = delegate { };
        public static event Action<bool> OnFocus = delegate { };
        public static event Action<string> OnDeepLink = delegate { };
        #endregion

        #region Singlton
        private static AffiseWorker _instance;

        public static AffiseWorker Instance
        {
            get
            {
                if (_instance is not null) return _instance;

                _instance = FindObjectOfType<AffiseWorker>();
                if (_instance is null)
                {
                    _instance = new GameObject($"[{nameof(AffiseWorker)}]").AddComponent<AffiseWorker>();
                    DontDestroyOnLoad(_instance.gameObject);
                    OnStart.Invoke();
                    Application.deepLinkActivated += OnDeepLink;
                }

                return _instance;
            }
        }
        private void Awake()
        {
            if (_instance is null) return;
            // Prevent duplication
            Destroy(gameObject);
        }
        #endregion

        public static Coroutine Work(IEnumerator task)
        {
            if (Application.isPlaying) return Instance.StartCoroutine(task);
            Debug.LogError("Can not run coroutine outside of play mode.");
            return null;
        }

        #region Application state
        private void OnApplicationQuit()
        {
            OnQuit.Invoke();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            OnPause.Invoke(pauseStatus);
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            OnFocus.Invoke(hasFocus);
        }
        #endregion
    }
}