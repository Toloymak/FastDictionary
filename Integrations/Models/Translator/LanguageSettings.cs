namespace Integrations.Models.Translator
{
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