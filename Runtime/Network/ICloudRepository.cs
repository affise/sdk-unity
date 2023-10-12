#nullable enable
using System;
using System.Collections.Generic;
using AffiseAttributionLib.Network.Entity;

namespace AffiseAttributionLib.Network
{
    public interface ICloudRepository
    {
        void Send(
            List<PostBackModel> data,
            string url,
            Action<HttpResponse>? onComplete = null
        );
    }
}