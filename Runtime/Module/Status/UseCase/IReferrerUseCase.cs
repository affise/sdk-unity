#nullable enable
using System.Collections.Generic;
using AffiseAttributionLib.Modules;
using AffiseAttributionLib.Referrer;

namespace AffiseAttributionLib.Module.Status.UseCase
{
    public interface IReferrerUseCase
    {
        void GetReferrer(OnReferrerCallback onComplete);

        string? ParseStatus(List<AffiseKeyValue> status);
    }
}