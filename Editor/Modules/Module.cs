#nullable enable

using System;
using UnityEngine;

namespace AffiseAttributionLib.Editor.Modules
{
    [Serializable]
    internal class Module
    {
        [SerializeField] public string name = "None";
        [SerializeField] public bool android;
        [SerializeField] public bool ios;

        [HideInInspector] public bool androidModule;
        [HideInInspector] public bool iosModule;

        public Module Copy(bool? androidEnabled = null, bool? iosEnabled = null)
        {
            return new Module
            {
                name = name,
                android = androidEnabled ?? android,
                ios = iosEnabled ?? ios,
                androidModule = androidModule,
                iosModule = iosModule,
            };
        }

        public override string ToString()
        {
            return $"module={name}; android={androidModule}; ios={iosModule};";
        }
    }
}