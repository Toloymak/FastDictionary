using System.Collections.Generic;

namespace Core.Models
{
    public class WordModel
    {
        public string Original { get; set; }
        public IList<string> Translate { get; set; }

        public WordModel()
        {
            
        }
        
        public WordModel(string original, string translate)
        {
            Original = original;
            Translate = new List<string>() { translate };
        }
        
        public WordModel(string original, IList<string> translates)
        {
            Original = original;
            Translate = translates;
        }
    }
}