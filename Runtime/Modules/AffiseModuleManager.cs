#nullable enable
using System;
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
            InitAffiseModules((module) =>
            {
                module.Dependencies(
                    _logsManager,
                    dependencies,
                    _postBackModelFactory.GetProviders()
                );

                if (module.IsManual == false)
                {
                    ModuleStart(module);
                }
            });
        }

        public void Status(AffiseModules module, OnKeyValueCallback onComplete)
        {
            var affiseModule = GetModule(module);
            if (affiseModule is not null)
            {
                affiseModule.Status(onComplete);
            }
            else
            {
                onComplete.Invoke(new List<AffiseKeyValue>
                {
                    new("error", $"module \"{module.Module()}\" not found")
                });
            }
        }

        public void ManualStart(AffiseModules module)
        {
            var affiseModule = GetModule(module);
            if (affiseModule is null) return;
            if (affiseModule.IsManual == false) return;
            ModuleStart(affiseModule);
        }

        private void ModuleStart(AffiseModule module)
        {
            module.Start();
            _postBackModelFactory.AddProviders(module.Providers());
        }

        private AffiseModule? GetModule(AffiseModules name)
        {
            return _modules.ContainsKey(name) ? _modules[name] : null;
        }

        private void InitAffiseModules(Action<AffiseModule> callback)
        {
            var affiseModules = new Dictionary<AffiseModules, AffiseModule>()
            {
                { AffiseModules.Advertising, new AdvertisingModule() },
                { AffiseModules.Network, new NetworkModule() },
                { AffiseModules.Phone, new PhoneModule() },
                { AffiseModules.Status, new StatusModule() },
            };

            foreach (var (name, module) in affiseModules)
            {
                _modules[name] = module;
                callback(module);
            }
        }
    }
}