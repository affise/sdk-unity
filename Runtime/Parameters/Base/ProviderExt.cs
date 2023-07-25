using System.Collections.Generic;
using System.Linq;

namespace AffiseAttributionLib.AffiseParameters.Base
{
    internal static class ProviderExt
    {
        public static Dictionary<string, object> MapProviders(this List<Provider> providers)
        {
            providers.RemoveAll(item => item == null);
            var createdTime = providers.GetProvider<CreatedTimeProvider>()?.ProvideWithDefault();
            var sorted = providers.OrderBy(p => p.Order).ToList();
            var result = new Dictionary<string, object>();
            foreach (var provider in sorted)
            {
                if (provider is null) continue;
                if (result.ContainsKey(provider.Key)) continue;

                result.Add(provider.Key, provider.GetValue(createdTime));
            }

            return result;
        }

        public static T GetProvider<T>(this List<Provider> providers) where T : Provider
        {
            foreach (var provider in providers)
            {
                if (provider is T result)
                {
                    return result;
                }
            }

            return null;
        }

        public static object GetValue(this Provider provider, long? createdTime)
        {
            return provider switch
            {
                CreatedTimeProvider => createdTime,
                StringPropertyProvider stringProvider => stringProvider.ProvideWithDefault(),
                BooleanPropertyProvider booleanProvider => booleanProvider.ProvideWithDefault(),
                LongPropertyProvider longProvider => longProvider.ProvideWithDefault(),
                AffAppTokenPropertyProvider affAppTokenProvider => affAppTokenProvider
                    .ProvideWithParamAndDefault(createdTime?.ToString() ?? ""),
                _ => null
            };
        }
    }
}