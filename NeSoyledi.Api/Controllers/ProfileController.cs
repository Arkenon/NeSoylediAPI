using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeSoyledi.Business.Abstract;
using NeSoyledi.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeSoyledi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IProfileService _profileService;
        public ProfileController(IProfileService profileService, IMapper mapper)
        {
            _mapper = mapper;
            _profileService = profileService;
        }

        [HttpGet("{id}")]
        public async Task<Profiles> GetById(int id)
        {
            var _profile = await _profileService.GetById(id);
            var profile = _mapper.Map<Profiles>(_profile);
            return profile;
        }

        [HttpGet("")]
        public IEnumerable<Profiles> Get(int pageNumber, int pageSize)
        {
            var _profile = _profileService.GetAll(pageNumber, pageSize);
            var profileList = _mapper.Map<IEnumerable<Profiles>>(_profile);
            var metadata = new
            {
                _profile.TotalCount,
                _profile.PageSize,
                _profile.CurrentPage,
                _profile.TotalPages,
                _profile.HasNext,
                _profile.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return profileList;
        }

        [HttpGet("")]
        public IEnumerable<Profiles> GetProfilesForHome(int pageNumber = 1, int pageSize = 12)
        {
            var _profile = _profileService.GetProfilesForHome(pageNumber, pageSize);
            var profileList = _mapper.Map<IEnumerable<Profiles>>(_profile);
            return profileList;
        }

    }
}
