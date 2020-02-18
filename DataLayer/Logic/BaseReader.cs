using System;
using System.Linq;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Logic
{
    public interface IBaseReader<T> where T : Entity
    {
        T Get(Guid id);
        IQueryable<T> All();
    }

    public abstract class BaseReader<T> : IBaseReader<T> where T : Entity
    {
        private readonly DbContext _dbContext;

        protected BaseReader(FdContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Get(Guid id) => _dbContext.Set<T>().FirstOrDefault(x => x.Id == id);
        
        public IQueryable<T> All() => _dbContext.Set<T>();
    }
}