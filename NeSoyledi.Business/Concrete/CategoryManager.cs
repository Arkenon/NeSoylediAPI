using NeSoyledi.Business.Abstract;
using NeSoyledi.Data;
using NeSoyledi.Data.Abstract;
using NeSoyledi.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace NeSoyledi.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly NeSoylediDbContext _context;

        public CategoryManager(ICategoryRepository categoryRepository, NeSoylediDbContext context)
        {
            _categoryRepository = categoryRepository;
            _context = context;
        }
        public IQueryable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public IQueryable<Category> GetAllPaged(int page, int pageSize)
        {
            return _categoryRepository.GetAllPaged(page, pageSize);
        }

        public Task<Category> GetWithDiscourses(int id)
        {
            return _context.Set<Category>()
                        .AsNoTracking().Include(x => x.Discourses)
                        .FirstOrDefaultAsync(e => e.Id == id);
        }

        public Task<Category> GetWithVersus(int id)
        {
            return _context.Set<Category>()
                        .AsNoTracking().Include(x => x.Versus)
                        .FirstOrDefaultAsync(e => e.Id == id);
        }

        public Task<Category> GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }
        public async Task Create(Category entity)
        {
            await _categoryRepository.Create(entity);
        }
        public async Task Update(int id, Category entity)
        {
            await _categoryRepository.Update(id, entity);
        }
        public async Task Delete(int id)
        {
            await _categoryRepository.Delete(id);
        }
    }
}
