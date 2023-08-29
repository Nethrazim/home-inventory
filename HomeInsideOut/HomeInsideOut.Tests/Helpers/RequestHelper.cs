using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HomeInsideOut.Tests.Helpers
{
    public class RequestHelper
    {
        private HttpClient httpClient { get; set; }
        public RequestHelper(HttpClient httpClient) { this.httpClient = httpClient; }

        public async Task<(TResponse response, HttpResponseMessage httpResponse)> sendGet<TRequest, TResponse>(string uri, TRequest request, string authorizationToken)
        {
            return await SendHttpRequest<TRequest, TResponse>(uri, HttpMethod.Get, request, authorizationToken);
        }

        public async Task<(TResponse response, HttpResponseMessage httpResponse)> sendPost<TRequest, TResponse>(string uri, TRequest request, string authorizationToken)
        {
            return await SendHttpRequest<TRequest, TResponse>(uri, HttpMethod.Post, request, authorizationToken);
        }

        public async Task<(TResponse response, HttpResponseMessage httpResponse)> sendPut<TRequest, TResponse>(string uri, TRequest request, string authorizationToken)
        {
            return await SendHttpRequest<TRequest, TResponse>(uri, HttpMethod.Put, request, authorizationToken);
        }

        private async Task<(TResponse, HttpResponseMessage)> SendHttpRequest<TRequest, TResponse>(string uri, HttpMethod httpMethod, TRequest request, string authorizationToken)
        {
            HttpRequestMessage requestMessage = CreateHttpRequestMessage(uri, httpMethod, request, authorizationToken);

            var httpResponse = await httpClient.SendAsync(requestMessage);
            
            if (httpResponse == null)
            {
                return default((TResponse, HttpResponseMessage));
            }

            var response = JsonConvert.DeserializeObject<TResponse>(await httpResponse.Content.ReadAsStringAsync());
            return (response, httpResponse);
        }

        private HttpRequestMessage CreateHttpRequestMessage<TRequest>(string uri, HttpMethod httpMethod, TRequest request, string token = "")
        {
            var httpRequest = new HttpRequestMessage(httpMethod, uri)
            {
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(request), 
                Encoding.UTF8, 
                "application/json")
            };
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return httpRequest;
        }
    }
}
