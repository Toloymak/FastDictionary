using Clients;
using Clients.EntitiClients;
using Moq;
using NUnit.Framework;

namespace ApiUnitTests.ClientsTests
{
    public class WordsClientTests
    {
        private WorldsClient _worldsClient;

        [SetUp]
        public void SetUp()
        {
            var apiClient = new Mock<IApiClient>();
            
            _worldsClient = new WorldsClient(apiClient.Object);
        }

        [Test]
        public void Get()
        {
            var actual = _worldsClient.Get();
            
            Assert.IsNotNull(actual);
        }
    }
}