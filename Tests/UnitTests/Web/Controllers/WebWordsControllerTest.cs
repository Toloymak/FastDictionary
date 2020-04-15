using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLogic.Entities.Words;
using Clients.EntitiClients;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using UnitTestCore.Extensions;
using Web.Controllers;

namespace ApiUnitTests.Web.Controllers
{
    public class WorldClient: TestBase
    {
        private new Mock<IWorldsClient> _wordClient;
        
        private WordsController _wordsController;
        
        [SetUp]
        public void Setup()
        {
            _wordClient = new Mock<IWorldsClient>();

        }
        
        [Test]
        public void Get_OneWord()
        {
            IList<GetWordDto> expectedResult = new List<GetWordDto>()
            {
                new GetWordDto()
            };
            
            var actual = ExecuteGetAndTakeValue(expectedResult);;
            
            Assert.AreEqual(expectedResult, actual);
                
        }
        
        [Test]
        public void Get_TwoWords()
        {
            IList<GetWordDto> expectedResult = new List<GetWordDto>()
            {
                new GetWordDto(),
                new GetWordDto(),
            };
            
            _wordClient.Setup(x => x.Get()).Returns(GetTaskResult(expectedResult));
            
            var actual = ExecuteGetAndTakeValue(expectedResult);;
            Assert.AreEqual(expectedResult, actual);
        }
        
        [Test]
        public void Get_Null_EmptyList()
        {
            var expectedResult = new List<GetWordDto>();
            
            var actual = ExecuteGetAndTakeValue(null);;
            Assert.AreEqual(expectedResult, actual);
        }
        
        [Test]
        public void Get_EmptyList_EmptyList()
        {
            var expectedResult = new List<GetWordDto>();
            
            var actual = ExecuteGetAndTakeValue(expectedResult);;
            Assert.AreEqual(expectedResult, actual);
        }
        
        private IList<GetWordDto> ExecuteGetAndTakeValue(IList<GetWordDto> wordsDtos)
        {
            _wordClient.Setup(x => x.Get()).Returns(GetTaskResult(wordsDtos));
            _wordsController = new WordsController(_wordClient.Object);
            
            var result = _wordsController.Get().Result.GetOkObjectResult().Value as IList<GetWordDto>;
            
            return result;
        }
    }
}