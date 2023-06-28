using System.IO;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace AffiseAttributionLib.Editor.Utils
{
    [ScriptedImporter(1, "rb")]
    public class RubyImporter : ScriptedImporter
    {
        public override void OnImportAsset(AssetImportContext ctx)
        {
            var rbAsset = new TextAsset(File.ReadAllText(ctx.assetPath));
            ctx.AddObjectToAsset("text", rbAsset);
            ctx.SetMainObject(rbAsset);
        }
    }
}