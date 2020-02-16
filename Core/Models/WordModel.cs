namespace Core.Models
{
    public class WordModel
    {
        public string Original { get; set; }
        public string Translate { get; set; }

        public WordModel(string original, string translate)
        {
            Original = original;
            Translate = translate;
        }
    }
}