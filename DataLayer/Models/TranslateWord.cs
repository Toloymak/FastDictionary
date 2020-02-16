using System;

namespace DataLayer.Models
{
    public class TranslateWord : Entity
    {
        public string Text { get; set; }
        public Guid OriginalWordId { get; set; }
        
        public OriginalWord OriginalWord { get; set; } 
    }
}