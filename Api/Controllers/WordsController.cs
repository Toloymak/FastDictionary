using System.Collections.Generic;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class WordsController : BaseController
    {
        private readonly IWordService _wordService;
        
        public WordsController(IWordService wordService)
        {
            _wordService = wordService;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var wordModels = _wordService.GetAllWordModels();

            return Ok(wordModels);
        }
    }
}