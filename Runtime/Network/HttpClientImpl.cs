#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AffiseAttributionLib.Debugger.Network;
using UnityEngine.Networking;

namespace AffiseAttributionLib.Network
{
    public class HttpClientImpl : IHttpClient
    {
        private DebugOnNetworkCallback? _debugRequest;

        public void SetDebug(DebugOnNetworkCallback debugNetwork)
        {
            _debugRequest = debugNetwork;
        }

        public IEnumerator ExecuteRequest(
            string httpsUrl,
            IHttpClient.Method method,
            string data,
            Dictionary<string, string> headers,
            Action<HttpResponse>? onComplete = null
        )
        {
            //Create data bytes
            var encodedData = Encoding.UTF8.GetBytes(data);
            
            //Create connection
            var request = new UnityWebRequest(httpsUrl);
            request.uploadHandler = new UploadHandlerRaw(encodedData);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.method = RequestMethod(method);

            //Add headers
            foreach (var (key, value) in headers)
            {
                request.SetRequestHeader(key, value);
            }
            
            //Send request
            yield return request.SendWebRequest();

            var responseCode = request.responseCode;
            var responseMessage = request.error ?? "";
            var responseBody = request.downloadHandler.text;

            var response = new HttpResponse(
                code: responseCode,
                message: responseMessage,
                body: responseBody
            );
            
            // Complete request
            onComplete?.Invoke(response);
            
            // Debug network
            _debugRequest?.Invoke(
                request: new HttpRequest(
                    url: httpsUrl, 
                    method: method, 
                    headers: headers,
                    body: data
                ), 
                response: response
            );
            
            //Disconnect
            request.Dispose();
        }

        private static string RequestMethod(IHttpClient.Method method)
        {
            return method switch
            {
                IHttpClient.Method.GET => UnityWebRequest.kHttpVerbGET,
                IHttpClient.Method.POST => UnityWebRequest.kHttpVerbPOST,
                _ => UnityWebRequest.kHttpVerbPOST
            };
        }
    }
}