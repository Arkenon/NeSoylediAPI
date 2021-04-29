using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeSoyledi.Business.Abstract
{
    public interface IBusinessService<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAllPaged(int page, int pageSize);

        Task<TEntity> GetById(int id);

        Task Create(TEntity entity);

        Task Update(int id, TEntity entity);

        Task Delete(int id);
    }
}
