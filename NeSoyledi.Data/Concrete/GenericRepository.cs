using Microsoft.EntityFrameworkCore;
using NeSoyledi.Data.Abstract;
using NeSoyledi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NeSoyledi.Data.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly NeSoylediDbContext _dbContext;
        public GenericRepository(NeSoylediDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<TEntity> GetAll(int pageNumber, int pageSize)
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }
        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => e.Id == id);
        }
        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> where)
        {
            return _dbContext.Set<TEntity>().AsNoTracking().Where(where);
        }
        public int Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }
        public void Update(int id, TEntity entity)
        {
            entity.Id = id;
            _dbContext.Set<TEntity>().Update(entity);

            _dbContext.SaveChanges();
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
