using DataLayer.Models;

namespace DataLayer.Logic.TranslateWords
{
    public interface ITranslateWordReader : IBaseReader<TranslateWord>
    {
    }

    public class TranslateWordReader : BaseReader<TranslateWord>, ITranslateWordReader
    {
        public TranslateWordReader(FdContext dbContext) : base(dbContext)
        {
        }
    }
}