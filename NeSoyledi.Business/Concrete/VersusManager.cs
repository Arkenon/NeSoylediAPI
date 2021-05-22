using Microsoft.EntityFrameworkCore;
using NeSoyledi.Business.Abstract;
using NeSoyledi.Data;
using NeSoyledi.Data.Abstract;
using NeSoyledi.Data.Helpers;
using NeSoyledi.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NeSoyledi.Business.Concrete
{
    public class VersusManager : IVersusService
    {
        private IVersusRepository _versusRepository;
        private readonly NeSoylediDbContext _context;
        public VersusManager(IVersusRepository versusRepository, NeSoylediDbContext context)
        {
            _context = context;
            _versusRepository = versusRepository;
        }

        public PagedList<Versus> GetAll(int pageNumber, int pageSize)
        {
            return PagedList<Versus>.ToPagedList(_versusRepository.GetAll(pageNumber, pageSize)
                .Include(x => x.Category), pageNumber, pageSize);
        }

        public async Task<Versus> GetById(int id)
        {
            return await _context.Set<Versus>().AsNoTracking().Include(x => x.Category).FirstOrDefaultAsync(e => e.Id == id);
        }

        public IQueryable<Versus> GetVersusForHome(int pageNumber, int pageSize)
        {
            return _versusRepository.GetAll(pageNumber, pageSize).Include(x => x.Category).OrderBy(r => Guid.NewGuid()).Take(pageSize);
        }
        public void Create(Versus entity)
        {
            _versusRepository.Create(entity);
        }

        public async Task Delete(int id)
        {
            await _versusRepository.Delete(id);
        }

        public void Update(int id, Versus entity)
        {
            _versusRepository.Update(id, entity);
        }

        public IQueryable<Versus> Where(Expression<Func<Versus, bool>> where)
        {
            return _versusRepository.Where(where);
        }
    }
}
