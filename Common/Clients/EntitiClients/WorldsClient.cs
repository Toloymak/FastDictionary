using System.Collections.Generic;
using System.Threading.Tasks;
using ApiLogic.Entities.Words;

namespace Clients.EntitiClients
{
    public interface IWorldsClient
    {
        Task<IList<GetWordDto>> Get();
    }

    public class WorldsClient : IWorldsClient
    {
        private IApiClient _apiClient;
        
        public WorldsClient(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IList<GetWordDto>> Get()
        {
            return new List<GetWordDto>();
        }
    }
}