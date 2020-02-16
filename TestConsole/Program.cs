using System.Threading.Tasks;
using Integrations.Clients;
using TestConsole.Tests;

namespace TestConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new MsTranslator().Translate("Test");
        }
    }
}