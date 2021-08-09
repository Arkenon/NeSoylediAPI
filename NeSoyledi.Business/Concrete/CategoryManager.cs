using NeSoyledi.Business.Abstract;
using NeSoyledi.Data.Abstract;
using NeSoyledi.Data.Helpers;
using NeSoyledi.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NeSoyledi.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public PagedList<Category> GetAll(int pageNumber, int pageSize)
        {
            return PagedList<Category>.ToPagedList(_categoryRepository.GetAll(pageNumber, pageSize), pageNumber, pageSize);
        }
        public async Task<Category> GetById(int id)
        {
            return await _categoryRepository.GetById(id);
        }
        public IQueryable<Category> Where(Expression<Func<Category, bool>> where)
        {
            return _categoryRepository.Where(where);
        }
        public void Create(Category entity)
        {
            _categoryRepository.Create(entity);
        }
        public void Update(int id, Category entity)
        {
            _categoryRepository.Update(id, entity);
        }
        public async Task Delete(int id)
        {
            await _categoryRepository.Delete(id);
        }
    }
}
