using System;
using AffiseAttributionLib.Editor.Utils;
using AffiseAttributionLib.Extensions;
using AffiseAttributionLib.Init;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace AffiseAttributionLib.Editor.Build
{
    public class AffiseBuildProcessor : IPreprocessBuildWithReport
    {
        private const string k_DefaultVersion = "unknown";
        private const string k_PackageDisplayName = "affise";
        private const string k_PackageVersionField = "version";

        public int callbackOrder => 0;

        public void OnPreprocessBuild(BuildReport report)
        {
            PackageUtils.Find(
                k_PackageDisplayName,
                result => { UpdateAffiseVersion(result.version); },
                () => { FindAsAsset(k_PackageDisplayName); }
            );
        }

        private void FindAsAsset(string name)
        {
            PackageUtils.FindAsAsset(name, (result) => { UpdateAffiseVersion(result[k_PackageVersionField]); },
                () => { UpdateAffiseVersion(k_DefaultVersion); });
        }

        private void UpdateAffiseVersion(string version)
        {
            var allSettings = Resources.FindObjectsOfTypeAll<AffiseSettings>();
            foreach (var settings in allSettings)
            {
                settings.buildInfo = new AffiseBuildInfo
                {
                    version = version,
                    timestamp = DateTime.UtcNow.GetTimeInMillis()
                };
            }
        }
    }
}