using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeSoyledi.Api.Models.DataTypeObjects;
using NeSoyledi.Business.Abstract;
using Newtonsoft.Json;
using System.Collections.Generic;
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
        public IEnumerable<DiscourseDTO> Get(int pageNumber, int pageSize)
        {
            var discourse = _discourseService.GetAll(pageNumber, pageSize);
            var discourseList = _mapper.Map<IEnumerable<DiscourseDTO>>(discourse);
            var metadata = new
            {
                discourse.TotalCount,
                discourse.PageSize,
                discourse.CurrentPage,
                discourse.TotalPages,
                discourse.HasNext,
                discourse.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return discourseList;
        }
        [HttpGet("{profileId}")]
        public IEnumerable<DiscourseWithProfileDTO> GetDiscoursesByProfileId(int pageNumber, int pageSize, int profileId, string order)
        {
            var discourse = _discourseService.GetDiscoursesByProfileId(pageNumber, pageSize, profileId, order);
            var discourseList = _mapper.Map<IEnumerable<DiscourseWithProfileDTO>>(discourse);
            var metadata = new
            {
                discourse.TotalCount,
                discourse.PageSize,
                discourse.CurrentPage,
                discourse.TotalPages,
                discourse.HasNext,
                discourse.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return discourseList;
        }

        [HttpGet("")]
        public IEnumerable<DiscourseDTO> GetDiscoursesForHome(int pageNumber = 1, int pageSize = 10)
        {
            var discourse = _discourseService.GetDiscoursesForHome(pageNumber, pageSize);
            var discourseList = _mapper.Map<IEnumerable<DiscourseDTO>>(discourse);
            return discourseList;
        }
    }
}
