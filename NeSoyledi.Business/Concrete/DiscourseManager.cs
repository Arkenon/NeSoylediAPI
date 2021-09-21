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
    public class DiscourseManager : IDiscourseService
    {
        private IDiscourseRepository _discourseRepository;
        private readonly NeSoylediDbContext _context;
        public DiscourseManager(IDiscourseRepository discourseRepository, NeSoylediDbContext context)
        {
            _context = context;
            _discourseRepository = discourseRepository;
        }
        public PagedList<Discourse> GetAll(int pageNumber, int pageSize)
        {
            return PagedList<Discourse>.ToPagedList(_discourseRepository.Where(x => x.ProfileId != null).Include(x => x.Profile).Include(x => x.Category).OrderByDescending(r => r.DiscourseDate), pageNumber, pageSize);
        }
        public IQueryable<Discourse> GetDiscoursesForHome(int pageNumber, int pageSize)
        {
            return _discourseRepository.GetAll(pageNumber, pageSize).Include(x => x.Profile).Include(x => x.Category).OrderBy(r => Guid.NewGuid()).Take(pageSize);
        }
        public PagedList<Discourse> GetDiscoursesByProfileId(int pageNumber, int pageSize, int profileId, string order, string startDate = "", string endDate = "")
        {

            if (order == "asc")
            {
                return PagedList<Discourse>.ToPagedList(_discourseRepository.Where(x => x.ProfileId == profileId)
                    .OrderBy(r => r.DiscourseDate), pageNumber, pageSize);
            }
            else if (order == "filtered")
            {
                DateTime _starDate = DateTime.Parse(startDate);
                DateTime _endDate;
                if (endDate != null)
                {
                    _endDate = DateTime.Parse(endDate);
                }
                else
                {
                    _endDate = DateTime.Today;
                }

                return PagedList<Discourse>.ToPagedList(_discourseRepository.Where(x => x.ProfileId == profileId && x.DiscourseDate >= _starDate && x.DiscourseDate <= _endDate)
                   .OrderByDescending(r => r.DiscourseDate), pageNumber, pageSize);
            }
            else
            {
                return PagedList<Discourse>.ToPagedList(_discourseRepository.Where(x => x.ProfileId == profileId)
                   .OrderByDescending(r => r.DiscourseDate), pageNumber, pageSize);
            }
        }

        public PagedList<Discourse> GetDiscoursesByUserId(int pageNumber, int pageSize, int userId)
        {
            return PagedList<Discourse>.ToPagedList(_discourseRepository.Where(x => x.UserId == userId)
                   .OrderByDescending(r => r.DiscourseDate), pageNumber, pageSize);
        }

        public PagedList<Discourse> GetDiscoursesByCategoryId(int pageNumber, int pageSize, int categoryId)
        {
            return PagedList<Discourse>.ToPagedList(_discourseRepository.Where(x => x.CategoryId == categoryId).Include(x => x.Profile)
                   .OrderByDescending(r => r.DiscourseDate), pageNumber, pageSize);
        }

        public async Task<Discourse> GetById(int id)
        {
            return await _context.Set<Discourse>().AsNoTracking().Include(x => x.Profile).Include(x => x.Category).FirstOrDefaultAsync(e => e.Id == id);
        }
        public int Create(Discourse entity)
        {
            return _discourseRepository.Create(entity);
        }
        public void Update(int id, Discourse entity)
        {
            _discourseRepository.Update(id, entity);
        }
        public async Task Delete(int id)
        {
            await _discourseRepository.Delete(id);
        }
        public IQueryable<Discourse> Where(Expression<Func<Discourse, bool>> where)
        {
            return _discourseRepository.Where(where);
        }
    }
}
