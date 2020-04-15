using System.Collections.Generic;
using System.Threading.Tasks;
using ApiLogic.Entities.Words;
using Clients.EntitiClients;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordsController : ControllerBase
    {
        private readonly IWorldsClient _worldsClient;
        
        public WordsController(IWorldsClient worldsClient)
        {
            _worldsClient = worldsClient;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var worlds = await _worldsClient.Get() ?? new List<GetWordDto>();

            return Ok(worlds);
        }
    }
}