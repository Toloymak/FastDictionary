using System.Threading.Tasks;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Logic
{
    public interface IBaseWriter<T> where T : Entity
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
        T InsertOrUpdate(T entity, bool needSave = true);
    }

    public class BaseWriter<T> : IBaseWriter<T> where T : Entity
    {
        private readonly DbContext _dbContext;

        public BaseWriter(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int SaveChanges() => _dbContext.SaveChanges();
        
        public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();

        public T InsertOrUpdate(T entity, bool needSave = true)
        {
            var newEntity = _dbContext.Set<T>().Update(entity).Entity;
            
            if (needSave)
                SaveChanges();

            return newEntity;
        }
        
        public async Task<T> InsertOrUpdateAsync(T entity, bool needSave = true)
        {
            var newEntity = _dbContext.Set<T>().Update(entity).Entity;
            
            if (needSave)
                await SaveChangesAsync();

            return newEntity;
        }
    }
}