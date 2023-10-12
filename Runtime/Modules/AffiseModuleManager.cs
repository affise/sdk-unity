#nullable enable
using System.Collections.Generic;
using AffiseAttributionLib.AffiseParameters.Factory;
using AffiseAttributionLib.Logs;
using AffiseAttributionLib.Module.Advertising;
using AffiseAttributionLib.Module.Network;
using AffiseAttributionLib.Module.Phone;
using AffiseAttributionLib.Module.Status;

namespace AffiseAttributionLib.Modules
{
    internal class AffiseModuleManager
    {
        private readonly ILogsManager _logsManager;
        private readonly PostBackModelFactory _postBackModelFactory;

        private readonly Dictionary<AffiseModules, AffiseModule> _modules = new();

        public AffiseModuleManager(ILogsManager logsManager, PostBackModelFactory postBackModelFactory)
        {
            _logsManager = logsManager;
            _postBackModelFactory = postBackModelFactory;
        }

        public void Init(List<object> dependencies)
        {
            _modules[AffiseModules.Advertising] = InitModule(new AdvertisingModule(), dependencies);
            _modules[AffiseModules.Network] = InitModule(new NetworkModule(), dependencies);
            _modules[AffiseModules.Phone] = InitModule(new PhoneModule(), dependencies);
            _modules[AffiseModules.Status] = InitModule(new StatusModule(), dependencies);
        }

        private AffiseModule InitModule(AffiseModule module, List<object> dependencies)
        {
            module.Init(_logsManager, dependencies, _postBackModelFactory.GetProviders());
            return module;
        }

        public void Status(AffiseModules module, OnKeyValueCallback onComplete)
        {
            if (_modules.ContainsKey(module))
            {
                _modules[module].Status(onComplete);
            }
            else
            {
                onComplete.Invoke(new List<AffiseKeyValue>
                {
                    new("error", $"module \"{module.Module()}\" not found")
                });
            }
        }
    }
}