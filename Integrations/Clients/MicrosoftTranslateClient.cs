

using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
        private static readonly string subscriptionKey = "";

        private const string endpoint_var = "TRANSLATOR_TEXT_ENDPOINT";
        private static readonly string endpoint = "https://api-nam.cognitive.microsofttranslator.com"; 
        //"https://translate-service.cognitiveservices.azure.com/sts/v1.0/issuetoken";
    }
    
    public class TranslationResult
    {
        public DetectedLanguage DetectedLanguage { get; set; }
        public TextResult SourceText { get; set; }
        public Translation[] Translations { get; set; }

        public string[] GetAllTranslations =>
            Translations.Select(t => t.Text).ToArray();
    }

    public class DetectedLanguage
    {
        public string Language { get; set; }
        public float Score { get; set; }
    }

    public class TextResult
    {
        public string Text { get; set; }
        public string Script { get; set; }
    }

    public class Translation
    {
        public string Text { get; set; }
        public TextResult Transliteration { get; set; }
        public string To { get; set; }
        public Alignment Alignment { get; set; }
        public SentenceLength SentLen { get; set; }
    }

    public class Alignment
    {
        public string Proj { get; set; }
    }

    public class SentenceLength
    {
        public int[] SrcSentLen { get; set; }
        public int[] TransSentLen { get; set; }
    }

    public class LanguageSettings
    {
        public string From { get; set; }
        public string To {get; set; }

        public LanguageSettings(string from, string to)
        {
            From = from;
            To = to;
        }

        public string GetTranslateString =>
            $"from={From}&to={To}";
    }
}