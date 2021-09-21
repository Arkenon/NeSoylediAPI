using NeSoyledi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NeSoyledi.Data.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll(int pageNumber, int pageSize);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> where);
        Task<TEntity> GetById(int id);
        int Create(TEntity entity);
        void Update(int id, TEntity entity);
        Task Delete(int id);
    }

}
