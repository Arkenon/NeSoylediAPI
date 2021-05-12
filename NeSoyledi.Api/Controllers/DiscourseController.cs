using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeSoyledi.Api.Models.DataTypeObjects;
using NeSoyledi.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeSoyledi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiscourseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IDiscourseService _discourseService;
        public DiscourseController(IDiscourseService discourseService, IMapper mapper)
        {
            _mapper = mapper;
            _discourseService = discourseService;
        }

        [HttpGet("{id}")]
        public async Task<DiscourseDTO> GetById(int id)
        {
            var _discourse = await _discourseService.GetById(id);
            var discourse = _mapper.Map<DiscourseDTO>(_discourse);
            return discourse;
        }

        [HttpGet("")]
        public IEnumerable<DiscourseDTO> GetAllPaged(int page = 1, int pageSize = 10)
        {
            var discourse = _discourseService.GetAllWithLazyPaged(page, pageSize);
            var discourseList = _mapper.Map<IEnumerable<DiscourseDTO>>(discourse);
            return discourseList;
        }
        [HttpGet("{profileId}")]
        public IEnumerable<DiscourseWithProfileDTO> GetDiscoursesByProfileId(int profileId,string order)
        {
            var discourse = _discourseService.GetDiscoursesByProfileId(profileId, order);
            var discourseList = _mapper.Map<IEnumerable<DiscourseWithProfileDTO>>(discourse);
            return discourseList;
        }

        [HttpGet("")]
        public IEnumerable<DiscourseDTO> GetDiscoursesForHome()
        {
            var discourse = _discourseService.GetDiscoursesForHome();
            var discourseList = _mapper.Map<IEnumerable<DiscourseDTO>>(discourse);
            return discourseList;
        }
    }
}
