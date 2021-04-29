using Microsoft.EntityFrameworkCore;
using NeSoyledi.Business.Abstract;
using NeSoyledi.Data;
using NeSoyledi.Data.Abstract;
using NeSoyledi.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NeSoyledi.Business.Concrete
{
    public class DiscourseManager : IDiscourseService
    {
        private IDiscourseRepository _discourseRepository;
        private readonly NeSoylediDbContext _context;
        public DiscourseManager(IDiscourseRepository discourseRepository, NeSoylediDbContext context)
        {
            _context = context;
            _discourseRepository = discourseRepository;
        }
        public IQueryable<Discourse> GetAll()
        {
            return _discourseRepository.GetAll();
        }

        public IQueryable<Discourse> GetAllPaged(int page, int pageSize)
        {
            return _discourseRepository.GetAllPaged(page, pageSize);
        }

        public IQueryable<Discourse> GetAllWithLazyPaged(int page, int pageSize)
        {
            var indexToGet = (page - 1) * pageSize;
            return _context.Set<Discourse>().AsNoTracking().Include(x => x.Profile).Include(x => x.Category).Skip(indexToGet).Take(pageSize);
        }

        public Task<Discourse> GetById(int id)
        {
            return _context.Set<Discourse>().AsNoTracking().Include(x => x.Profile).Include(x => x.Category)
                        .FirstOrDefaultAsync(e => e.Id == id); ;
        }
        public async Task Create(Discourse entity)
        {
            await _discourseRepository.Create(entity);
        }
        public async Task Update(int id, Discourse entity)
        {
            await _discourseRepository.Update(id, entity);
        }
        public async Task Delete(int id)
        {
            await _discourseRepository.Delete(id);
        }
    }
}
