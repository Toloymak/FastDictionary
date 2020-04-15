using System.Collections.Generic;
using System.Threading.Tasks;
using ApiLogic.Entities.Words;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class WordsController : ControllerBase
    {
        public async Task<IActionResult> Get()
        {
            var list = new List<GetWordDto>()
            {
                new GetWordDto()
                {
                    Word = "Test",
                    Translates = new List<string>()
                    {
                        "Translate1",
                        "Translate2"
                    },
                },
                new GetWordDto()
            };
            
            return Ok(list);
        }
    }
}