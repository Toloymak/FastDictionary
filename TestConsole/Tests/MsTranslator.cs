using System.Threading.Tasks;
using Integrations.Clients;

namespace TestConsole.Tests
{
    public class MsTranslator
    {
        public async Task Translate(string word)
        {
            System.Console.WriteLine("Start");

            var results = await new MicrosoftTranslateClient("en", "ru").SingleTranslate(word);
            foreach (var translation in results.GetAllTranslations)
            {
                System.Console.WriteLine($"{translation}");
            }

            System.Console.WriteLine("End");
        }
    }
}