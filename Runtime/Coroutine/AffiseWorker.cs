using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AffiseAttributionLib.Coroutine
{
    internal class AffiseWorker : MonoBehaviour
    {
        #region Application events

        public static event Action OnStart = delegate { };
        public static event Action OnQuit = delegate { };
        public static event Action<bool> OnPause = delegate { };
        public static event Action<bool> OnFocus = delegate { };
        public static event Action<string> OnDeepLink = delegate { };

        #endregion Application events

        #region Singlton

        private static AffiseWorker _instance;

        private static AffiseWorker Instance
        {
            get
            {
                if (_instance is not null) return _instance;
                _instance = FindObjectOfType<AffiseWorker>();
                if (_instance is not null) return _instance;
                _instance = CreateWorker();
                _instance.Init();
                return _instance;
            }
        }

        private static AffiseWorker CreateWorker()
        {
            return new GameObject($"[{nameof(AffiseWorker)}]").AddComponent<AffiseWorker>();
        }

        private void Init()
        {
            DontDestroyOnLoad(gameObject);
            OnStart.Invoke();
            Application.deepLinkActivated += OnDeepLink;
        }

        private void Awake()
        {
            if (_instance is null) return;
            // Prevent duplication
            Destroy(gameObject);
        }

        #endregion Singlton

        private readonly List<AffiseCoroutine> _coroutines = new();
        
        private AffiseCoroutine NewCoroutine(string id)
        {
            var result = AffiseCoroutine.Create(this, id);
            _coroutines.Add(result);
            return result;
        }

        private void GetCoroutine(Action<AffiseCoroutine> action)
        {
            foreach (var coroutine in _coroutines)
            {
                if (coroutine.IsActive) continue;
                action(coroutine);
                return;
            }

            action(NewCoroutine($"{_coroutines.Count + 1}"));
        }

        public static void Run(IEnumerator run)
        {
            Instance.GetCoroutine(coroutine =>
                coroutine.Run(run)
            );
        }

        public static void DelayRun(long delay, Action action)
        {
            Instance.GetCoroutine(coroutine =>
                coroutine.DelayRun(delay, action)
            );
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

        #endregion Application state
    }
}