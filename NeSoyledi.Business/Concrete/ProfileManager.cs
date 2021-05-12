using NeSoyledi.Business.Abstract;
using NeSoyledi.Entities;
using NeSoyledi.Data;
using NeSoyledi.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NeSoyledi.Business.Concrete
{
    public class ProfileManager : IProfileService
    {
        private IProfileRepository _profileRepository;
        private readonly NeSoylediDbContext _context;

        public ProfileManager(IProfileRepository profileRepository, NeSoylediDbContext neSoylediDbContext)
        {
            _profileRepository = profileRepository;
            _context = neSoylediDbContext;
        }
        public IQueryable<Profiles> GetAll()
        {
            return _profileRepository.GetAll();
        }

        public IQueryable<Profiles> GetAllPaged(int page, int pageSize)
        {
            return _profileRepository.GetAllPaged(page, pageSize);
        }

        public IQueryable<Profiles> GetAllWithLazyPaged(int page, int pageSize)
        {
            var indexToGet = (page - 1) * pageSize;
            return _context.Set<Profiles>().AsNoTracking().Skip(indexToGet).Take(pageSize);
        }

        public IQueryable<Profiles> GetProfilesForHome()
        {
            return _context.Set<Profiles>().AsNoTracking().OrderBy(r => Guid.NewGuid()).Take(12);
        }

        public async Task<Profiles> GetById(int id)
        {
            return await _profileRepository.GetById(id);
        }
        public async Task Create(Profiles entity)
        {
            await _profileRepository.Create(entity);
        }

        public async Task Delete(int id)
        {
            await _profileRepository.Delete(id);
        }

        public async Task Update(int id, Profiles entity)
        {
            await _profileRepository.Update(id, entity);
        }
    }
}
