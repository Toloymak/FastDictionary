using System;
using System.Linq;
using Core.Models;
using DataLayer.Models;

namespace Core.Mappers
{
    public static class WordModelMappers
    {
        public static OriginalWord ToOriginalWord(this WordModel wordModel)
        {
            return new OriginalWord()
            {
                Text = wordModel.Original,
                LastUpdate = DateTime.Now,
                TranslateWords = wordModel.Translate.Select(t =>
                    new TranslateWord()
                    {
                        Text = t
                    })
            };
        }
    }
}