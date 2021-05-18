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
        public void Create(Profiles entity)
        {
            _profileRepository.Create(entity);
        }
        public async Task Delete(int id)
        {
            await _profileRepository.Delete(id);
        }
        public void Update(int id, Profiles entity)
        {
            _profileRepository.Update(id, entity);
        }
        public IQueryable<Profiles> Where(Expression<Func<Profiles, bool>> where)
        {
            return _profileRepository.Where(where);
        }
    }
}
