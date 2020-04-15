using System.Collections.Generic;
using System.Linq;
using Api.Controllers;
using ApiLogic.Entities.Words;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using UnitTestCore.Extensions;

namespace ApiUnitTests.ApiTests.Controllers
{
    public class WordsControllerTests
    {
        private WordsController _wordsController;
        
        [SetUp]
        public void Setup()
        {
            _wordsController = new WordsController();
        }
        
        [Test]
        public void Get_HasValue()
        {
            var actual = ExecuteGetAndTakeValue();
            
            Assert.AreNotEqual(actual.Count, 0);
        }
        
        [Test]
        public void Get_FirstWorldsHasContent()
        {
            var actual = ExecuteGetAndTakeValue();
            
            Assert.IsNotNull(actual.FirstOrDefault()?.Word);
        }
        
        [Test]
        public void Get_FirstWorldsHasTranslate()
        {
            var actual = ExecuteGetAndTakeValue();
            
            Assert.IsNotNull(actual.FirstOrDefault()?.Translates);
            Assert.IsNotNull(actual.FirstOrDefault()?.Translates);
        }
        
        private IList<GetWordDto> ExecuteGetAndTakeValue()
        {
            _wordsController = new WordsController();
            
            var result = _wordsController.Get().Result.GetOkObjectResult().Value as IList<GetWordDto>;
            
            return result;
        }
    }
}