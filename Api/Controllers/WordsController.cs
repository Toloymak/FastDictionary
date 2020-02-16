using System.Collections.Generic;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class WordsController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            var wordList = new List<WordModel>()
            {
                new WordModel("TestOr1", "TestTr1"),
                new WordModel("TestOr2", "TestTr2"),
                new WordModel("TestOr3", "TestTr3"),
                new WordModel("TestOr4", "TestTr4"),
                new WordModel("TestOr5", "TestTr5"),
            };

            return Ok(wordList);
        }
    }
}