using System.Threading.Tasks;

namespace ApiUnitTests
{
    public class TestBase
    {
        public Task<T> GetTaskResult<T>(T result)
            => Task.FromResult(result);
    }
}