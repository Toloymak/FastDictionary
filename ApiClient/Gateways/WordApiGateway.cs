using System.Collections.Generic;
using System.Threading.Tasks;
using ApiClient.Models;
using Core.Models;

namespace ApiClient.Gateways
{
    public class WordApiGateway
    {
        private readonly InternalApiClient _internalApiClient;
        
        public WordApiGateway()
        {
            _internalApiClient = new InternalApiClient();
        }

        public async Task<ApiResponse<IList<WordModel>>> GetAllWords() 
            => await _internalApiClient.ExecuteGet<IList<WordModel>>("words");
    }
}