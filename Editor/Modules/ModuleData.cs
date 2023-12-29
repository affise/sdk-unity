#nullable enable


namespace AffiseAttributionLib.Editor.Modules
{
    internal class ModuleData
    {
        public string Module = "";

        public string Version = "";
        
        public override string ToString()
        {
            return $"name={Module}; version={Version};";
        }
    }
}