using System.Linq;
using System.Threading.Tasks;
using Core.Enums;
using Core.Extensions;
using Core.Models;
using Core.Services;
using DataLayer.Logic.TranslateWords;
using Integrations.Clients;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class TranslateController: BaseController
    {
        private readonly WordService _wordService;

        public TranslateController(WordService wordService)
        {
            _wordService = wordService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string text, LanguageEnum from, LanguageEnum to)
        {
            if (text == null)
                return BadRequest("Text can't be null");
            
            var translate = await new MicrosoftTranslateClient(from.Code(), to.Code())
                .SingleTranslate(text);
            
            var model = new WordModel(text, translate.GetAllTranslations.FirstOrDefault());

            return Ok(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(string source, string translate)
        {
            
            
            return Ok();
        }
        
    }
}