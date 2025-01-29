#nullable enable
using System.Collections.Generic;
using System.Linq;
using AffiseAttributionLib.Modules;
using AffiseAttributionLib.Referrer;
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.Module.Status.UseCase
{
    public class ReferrerUseCaseImpl : IReferrerUseCase
    {
        private readonly ICheckStatusUseCase? _checkStatusUseCase;
        private string? _referrer;
        private string _keyIsOrganic = "is_organic";
        private string _keyReferrer = "referrer";
        private string _organic = "utm_source=apple-store&utm_medium=organic";

        public ReferrerUseCaseImpl(ICheckStatusUseCase? checkStatusUseCase)
        {
            _checkStatusUseCase = checkStatusUseCase;
        }

        private string? GetStatusValue(string key, List<AffiseKeyValue> status)
        {
            return status.FirstOrDefault((keyValue) => keyValue.Key == key)?.Value;
        }

        public void GetReferrer(OnReferrerCallback onComplete)
        {
            if (_referrer is not null)
            {
                onComplete.Invoke(_referrer);
                return;
            }

            if (_checkStatusUseCase is null)
            {
                onComplete.Invoke(_referrer);
                return;
            }
            
            _checkStatusUseCase.Send((data) =>
            {
                onComplete.Invoke(ParseStatus(data));
            });
        }

        public string? ParseStatus(List<AffiseKeyValue> status)
        {
            if (_referrer is not null) return _referrer;
            
            var isOrganic = GetStatusValue(_keyIsOrganic, status)?.ToBoolean() ?? false;

            if (isOrganic)
            {
                _referrer = _organic;
            }
            else
            {
                _referrer = GetStatusValue(_keyReferrer, status);
            }

            return _referrer;
        }
    }
}