using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public class OriginalWord : Entity
    {
        public string Text { get; set; }
        public DateTime LastUpdate { get; set; }
        public int Priority { get; set; }
        
        public IEnumerable<TranslateWord> TranslateWords { get; set; }
    }
}