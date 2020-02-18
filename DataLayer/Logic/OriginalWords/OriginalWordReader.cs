using DataLayer.Models;

namespace DataLayer.Logic.OriginalWords
{
    public interface IOriginalWordReader : IBaseReader<OriginalWord>
    {
    }

    public class OriginalWordReader : BaseReader<OriginalWord>, IOriginalWordReader
    {
        public OriginalWordReader(FdContext dbContext) : base(dbContext)
        {
        }
    }
}