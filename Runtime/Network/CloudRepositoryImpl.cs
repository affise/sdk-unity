using System;
using System.Collections.Generic;
using AffiseAttributionLib.Converter;
using AffiseAttributionLib.Executors;
using AffiseAttributionLib.Network.Entity;
using AffiseAttributionLib.Network.Response;

namespace AffiseAttributionLib.Network
{
    public class CloudRepositoryImpl : ICloudRepository
    {
        private readonly IHttpClient _httpClientImpl;
        private readonly IConverter<List<PostBackModel>, string> _postBackModelToJsonStringConverter;
        private readonly IExecutorServiceProvider _executorServiceProvider;

        public CloudRepositoryImpl(
            IExecutorServiceProvider executorServiceProvider,
            IHttpClient httpClientImpl,
            IConverter<List<PostBackModel>, string> postBackModelToJsonStringConverter
        )
        {
            _executorServiceProvider = executorServiceProvider;
            _httpClientImpl = httpClientImpl;
            _postBackModelToJsonStringConverter = postBackModelToJsonStringConverter;
        }

        public void Send(
            List<PostBackModel> data,
            string url,
            Action<string> onSuccess,
            Action<ErrorResponse> onError
        )
        {
            CreateRequest(url, data, onSuccess, onError);
        }

        private void CreateRequest(
            string url,
            List<PostBackModel> data,
            Action<string> onSuccess = null,
            Action<ErrorResponse> onError = null
        )
        {
            _executorServiceProvider.Execute(
                _httpClientImpl.ExecuteRequest(
                    url,
                    IHttpClient.Method.Post,
                    _postBackModelToJsonStringConverter.Convert(data),
                    CreateHeaders(),
                    onSuccess,
                    onError
                )
            );
        }

        private Dictionary<string, string> CreateHeaders()
        {
            return new Dictionary<string, string>()
            {
                { "Content-Type", "application/json; charset=utf-8" }
            };
        }
    }
}