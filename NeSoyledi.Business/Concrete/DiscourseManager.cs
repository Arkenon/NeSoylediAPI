﻿using Microsoft.EntityFrameworkCore;
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
            return PagedList<Discourse>.ToPagedList(_discourseRepository.GetAll(pageNumber, pageSize)
                .Include(x => x.Profile).Include(x => x.Category), pageNumber, pageSize);
        }
        public IQueryable<Discourse> GetDiscoursesForHome(int pageNumber, int pageSize)
        {
            return _discourseRepository.GetAll(pageNumber, pageSize).Include(x => x.Profile).Include(x => x.Category).OrderBy(r => Guid.NewGuid()).Take(pageSize);
        }
        public PagedList<Discourse> GetDiscoursesByProfileId(int pageNumber, int pageSize, int profileId, string order)
        {
            if (order == "asc")
            {
                return PagedList<Discourse>.ToPagedList(_discourseRepository.Where(x => x.ProfileId == profileId)
                    .OrderBy(r => r.DiscourseDate), pageNumber, pageSize);
            }
            else
            {
                return PagedList<Discourse>.ToPagedList(_discourseRepository.Where(x => x.ProfileId == profileId)
                   .OrderByDescending(r => r.DiscourseDate), pageNumber, pageSize);
            }
        }
        public async Task<Discourse> GetById(int id)
        {
            return await _context.Set<Discourse>().AsNoTracking().Include(x => x.Profile).Include(x => x.Category).FirstOrDefaultAsync(e => e.Id == id);
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
        public IQueryable<Discourse> Where(Expression<Func<Discourse, bool>> where)
        {
            return _discourseRepository.Where(where);
        }
    }
}