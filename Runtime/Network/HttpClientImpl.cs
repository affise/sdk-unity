using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AffiseAttributionLib.Network.Response;
using UnityEngine.Networking;

namespace AffiseAttributionLib.Network
{
    public class HttpClientImpl : IHttpClient
    {
        public IEnumerator ExecuteRequest(
            string httpsUrl,
            IHttpClient.Method method,
            string data,
            Dictionary<string, string> headers,
            Action<string> onSuccess = null,
            Action<ErrorResponse> onError = null
        )
        {
            var encodedData = Encoding.UTF8.GetBytes(data);

            var request = new UnityWebRequest(httpsUrl);
            request.uploadHandler = new UploadHandlerRaw(encodedData);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.method = RequestMethod(method);

            //Add headers
            foreach (var (key, value) in headers)
            {
                request.SetRequestHeader(key, value);
            }

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success && request.responseCode == 200)
            {
                onSuccess?.Invoke(request.downloadHandler.text);
            }
            else
            {
                onError?.Invoke(new ErrorResponse(request.error, request.responseCode));
            }

            request.Dispose();
        }

        private string RequestMethod(IHttpClient.Method method)
        {
            var result = UnityWebRequest.kHttpVerbGET;
            if (method == IHttpClient.Method.Post)
            {
                result = UnityWebRequest.kHttpVerbPOST;
            }

            return result;
        }
    }
}