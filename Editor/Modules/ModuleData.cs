#nullable enable


namespace AffiseAttributionLib.Editor.Modules
{
    internal class ModuleData
    {
        public string Module = "";

        public string Version = "";
        
        public string? Comment = null;
        
        public bool Enabled = true;
        
        public override string ToString()
        {
            return $"name={Module}; version={Version}; enabled={Enabled}; comment={Comment};";
        }
    }
}