using System;
using System.Collections;
using UnityEngine;

namespace AffiseAttributionLib.Coroutine
{
    internal class AffiseCoroutine : MonoBehaviour
    {
        public bool IsActive => gameObject.activeSelf;

        public void Run(IEnumerator run)
        {
            if (!Application.isPlaying)
            {
                Debug.LogError("Can't run coroutine outside of play mode.");
                return;
            }

            gameObject.SetActive(true);
            StartCoroutine(CoroutineWithEnd(run));
        }

        public void DelayRun(long delay, Action action)
        {
            Run(DelayAction(delay, action));
        }

        private IEnumerator DelayAction(long delay, Action action)
        {
            yield return new WaitForSeconds(delay / 1000f);
            action.Invoke();
        }

        private IEnumerator CoroutineWithEnd(IEnumerator run)
        {
            yield return run;
            StopCoroutine(run);
            gameObject.SetActive(false);
        }

        public static AffiseCoroutine Create(AffiseWorker parent = null, string id = "1")
        {
            var coroutine = new GameObject($"[{nameof(AffiseCoroutine)}.{id}]").AddComponent<AffiseCoroutine>();
            if (parent is null) return coroutine;
            coroutine.transform.parent = parent.transform;
            return coroutine;
        }
    }
}