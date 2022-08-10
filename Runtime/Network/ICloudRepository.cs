using System;
using System.Collections.Generic;
using AffiseAttributionLib.Network.Entity;
using AffiseAttributionLib.Network.Response;
using UnityEngine.Networking;

namespace AffiseAttributionLib.Network
{
    public interface ICloudRepository
    {
        void Send(List<PostBackModel> data, string url, Action<string> onSuccess = null, Action<ErrorResponse> onError = null);
    }
}