using NeSoyledi.Data.Helpers;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NeSoyledi.Business.Abstract
{
    public interface IBusinessService<TEntity> where TEntity : class
    {
        PagedList<TEntity> GetAll(int pageNumber, int pageSize);
        Task<TEntity> GetById(int id);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> where);
        int Create(TEntity entity);
        void Update(int id, TEntity entity);
        Task Delete(int id);
    }
}
