using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeSoyledi.Business.Abstract;
using NeSoyledi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
