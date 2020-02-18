using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Logic.TranslateWords
{
    public interface ITranslateWordWriter : IBaseWriter<TranslateWord>
    {
    }
    
    public class TranslateWordWriter : BaseWriter<TranslateWord> , ITranslateWordWriter
    {
        public TranslateWordWriter(DbContext dbContext) : base(dbContext)
        {
        }
    }
}