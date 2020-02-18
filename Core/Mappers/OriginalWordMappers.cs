using System.Collections.Generic;
using System.Linq;
using Core.Models;
using DataLayer.Models;

namespace Core.Mappers
{
    public static class OriginalWordMappers
    {
        public static WordModel ToWordModel(this OriginalWord originalWord)
        {
            var translates = originalWord.TranslateWords.Select(t => t.Text).ToList();
            
            return new WordModel(originalWord.Text, translates);
        }

        public static IEnumerable<WordModel> ToWordModels(this IQueryable<OriginalWord> originalWords)
        {
            return originalWords
                .ToList()
                .Select(o => o.ToWordModel());
        }
    }
}