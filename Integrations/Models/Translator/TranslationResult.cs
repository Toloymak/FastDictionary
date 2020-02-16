using System.Linq;

namespace Integrations.Models.Translator
{
    public class TranslationResult
    {
        public DetectedLanguage DetectedLanguage { get; set; }
        public TextResult SourceText { get; set; }
        public Translation[] Translations { get; set; }

        public string[] GetAllTranslations =>
            Translations.Select(t => t.Text).ToArray();
    }
}