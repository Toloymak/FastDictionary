using System;
using RestSharp;

namespace Clients
{
    public interface IApiClient
    {
    }

    public class ApiClient : IApiClient
    {
        private readonly IRestClient _restClient;

        public ApiClient(IRestClient restClient)
        {
            _restClient = restClient;
        }
    }
}