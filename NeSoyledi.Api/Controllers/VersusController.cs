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
    public class VersusController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IVersusService _versusService;
        private IDiscourseService _discourseService;
        public VersusController(IVersusService versusService, IMapper mapper, IDiscourseService discourseService)
        {
            _mapper = mapper;
            _versusService = versusService;
            _discourseService = discourseService;
        }

        [HttpGet("{id}")]
        public async Task<VersusDTO> GetById(int id)
        {
            var _versus = await _versusService.GetById(id);
            var versus = _mapper.Map<VersusDTO>(_versus);
            return versus;
        }

        [HttpGet("")]
        public IEnumerable<VersusForHomeDTO> Get(int pageNumber = 1, int pageSize = 10)
        {
            var versus = _versusService.GetAll(pageNumber, pageSize);
            var versusList = _mapper.Map<IEnumerable<VersusForHomeDTO>>(versus);
            var metadata = new
            {
                versus.TotalCount,
                versus.PageSize,
                versus.CurrentPage,
                versus.TotalPages,
                versus.HasNext,
                versus.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return versusList;
        }

        [HttpGet("")]
        public IEnumerable<VersusForHomeDTO> GetVersusForHome(int pageNumber = 1, int pageSize = 6)
        {
            var versus = _versusService.GetVersusForHome(pageNumber, pageSize);
            var versusList = _mapper.Map<IEnumerable<VersusForHomeDTO>>(versus);
            return versusList;
        }
    }
}
