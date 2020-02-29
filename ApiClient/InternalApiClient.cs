using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ApiClient.Models;
using Core.Models;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ApiClient
{
    public class InternalApiClient
    {
        public RestClient Client { get; private set; }
        
        public InternalApiClient()
        {
            Client = new RestClient()
            {
                BaseUrl = new Uri("http://localhost:5010/")
            };
            
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            Client.RemoteCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        }

        public async Task<ApiResponse<T>> ExecuteGet<T>(string url, Dictionary<string, string> parameters = null)
        {
            var restRequest = new RestRequest(url, Method.GET);

            AddParameters(restRequest, parameters, ParameterType.QueryString);

            var response = await Client.ExecuteAsync(restRequest);

            return DeserializeResult<T>(response);
        }

        public async Task<ApiResponse<T>> ExecutePost<T>(string url, object body)
        {
            var restRequest = new RestRequest(url, Method.POST);

            restRequest.AddJsonBody(body);

            var response = await Client.ExecuteAsync(restRequest);

            return DeserializeResult<T>(response);
        }
        
        private static ApiResponse<T> DeserializeResult<T>(IRestResponse response)
        {
            try
            {
                var resultContent = JsonConvert.DeserializeObject<T>(response.Content);
                return new ApiResponse<T>(resultContent);
            }
            catch (Exception e)
            {
                return new ApiResponse<T>(e);
            }
        }

        private static void AddParameters(RestRequest restRequest,
            Dictionary<string, string> parameters,
            ParameterType type)
        {
            if (parameters != null)
                foreach (var parameter in parameters)
                    restRequest.Parameters.Add(new Parameter(parameter.Key, parameter.Value, type));
        }
    }
}