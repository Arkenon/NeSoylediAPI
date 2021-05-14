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
using System.Linq.Expressions;
using NeSoyledi.Data.Helpers;

namespace NeSoyledi.Business.Concrete
{
    public class ProfileManager : IProfileService
    {
        private IProfileRepository _profileRepository;
        public ProfileManager(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }
        public PagedList<Profiles> GetAll(int pageNumber, int pageSize)
        {
            return PagedList<Profiles>.ToPagedList(_profileRepository.GetAll(pageNumber,pageSize),pageNumber,pageSize);
        }
        public PagedList<Profiles> GetProfilesForHome(int pageNumber, int pageSize)
        {
            return PagedList<Profiles>.ToPagedList(_profileRepository.GetAll(pageNumber, pageSize).OrderBy(r => Guid.NewGuid()), pageNumber, pageSize);
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
        public IQueryable<Profiles> Where(Expression<Func<Profiles, bool>> where)
        {
            return _profileRepository.Where(where);
        }
    }
}
