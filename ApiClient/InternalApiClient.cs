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

        public async Task<ApiResponse<T>> ExecuteGet<T>(string url)
        {
            var restRequest = new RestRequest(url, Method.GET);
            var response = await Client.ExecuteAsync(restRequest);

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
    }
}