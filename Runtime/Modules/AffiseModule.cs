#nullable enable
using System;
using System.Collections.Generic;
using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Logs;

namespace AffiseAttributionLib.Modules
{
    public abstract class AffiseModule
    {
        protected ILogsManager? _logsManager;
        protected List<object> _dependencies = new();
        protected List<Provider> _baseProviders = new();

        public void Init(ILogsManager logsManager, List<object> dependencies, List<Provider> providers)
        {
            _logsManager = logsManager;
            _dependencies = dependencies;
            _baseProviders = providers;
            Init(logsManager);
        }

        protected abstract void Init(ILogsManager logsManager);

        public virtual void Status(OnKeyValueCallback onComplete)
        {
            onComplete(new List<AffiseKeyValue>
            {
                new("state", "enabled")
            });
        }

        public T? GetProvider<T>() where T : Provider
        {
            return _baseProviders.GetProvider<T>();
        }

        public List<Provider> GetProviders(List<Type> types)
        {
            return _baseProviders.GetProviders(types);
        }

        public List<Provider> GetRequestProviders()
        {
            return _baseProviders.GetRequestProviders();
        }

        public T? Get<T>() where T : class
        {
            foreach (var obj in _dependencies)
            {
                if (obj is T result)
                {
                    return result;
                }
            }

            return null;
        }
    }
}