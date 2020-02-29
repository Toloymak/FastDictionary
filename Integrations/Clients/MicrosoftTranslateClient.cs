

using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Integrations.Models.Translator;
using Newtonsoft.Json;

namespace Integrations.Clients
{
    public class MicrosoftTranslateClient
    {
        public MicrosoftTranslateClient(string from, string to)
        {
            _languageSettings = new LanguageSettings(from, to);
        }

        private LanguageSettings _languageSettings;

        public async Task<TranslationResult> SingleTranslate(string text)
        {
            using var client = new HttpClient();
            using var request = new HttpRequestMessage();
            
            ConfigureRequest(request, text);
            
            var translationResults = await Translate(client, request);

            return translationResults.FirstOrDefault();
        }

        private static async Task<TranslationResult[]> Translate(HttpClient client, HttpRequestMessage request)
        {
            var response = await client.SendAsync(request).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync();

            var deserializedOutput = JsonConvert.DeserializeObject<TranslationResult[]>(result);
            return deserializedOutput;
        }

        private void ConfigureRequest(HttpRequestMessage request, string text)
        {
            var requestBody = JsonConvert.SerializeObject(new object[] { new { Text = text } });

            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri($"{AzureEndpoint}/{TranslateResource}&{_languageSettings.GetTranslateString}");
            request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            request.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
        }

        private const string TranslateResource = "translate?api-version=3.0";
        private const string AzureEndpoint = "https://api-nam.cognitive.microsofttranslator.com";
        
        private const string key_var = "TRANSLATOR_TEXT_SUBSCRIPTION_KEY";
        private static readonly string subscriptionKey = Environment.GetEnvironmentVariable(key_var);

        private const string endpoint_var = "TRANSLATOR_TEXT_ENDPOINT";
        private static readonly string endpoint = "https://api-nam.cognitive.microsofttranslator.com"; 
    }
}