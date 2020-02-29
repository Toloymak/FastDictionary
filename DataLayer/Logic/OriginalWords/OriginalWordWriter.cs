using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Logic.OriginalWords
{
    public interface IOriginalWordWriter : IBaseWriter<OriginalWord>
    {
    }

    public class OriginalWordWriter : BaseWriter<OriginalWord>, IOriginalWordWriter
    {
        public OriginalWordWriter(FdContext dbContext) : base(dbContext)
        {
        }
    }
}