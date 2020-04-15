using System.Collections.Generic;

namespace ApiLogic.Entities.Words
{
    public class GetWordDto
    {
        public string Word { get; set; }
        public IList<string> Translates { get; set; }
    }
}