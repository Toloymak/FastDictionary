using System.Collections.Generic;

namespace DataLayer.Models
{
    public class OriginalWord : Entity
    {
        public string Text { get; set; }
        
        public IEnumerable<TranslateWord> TranslateWords { get; set; }
    }
}