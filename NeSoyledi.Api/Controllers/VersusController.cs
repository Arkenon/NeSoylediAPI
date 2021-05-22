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
        public VersusController(IVersusService versusService, IMapper mapper)
        {
            _mapper = mapper;
            _versusService = versusService;
        }

        [HttpGet("{id}")]
        public async Task<VersusDTO> GetById(int id)
        {
            var _versus = await _versusService.GetById(id);
            var versus = _mapper.Map<VersusDTO>(_versus);
            return versus;
        }

        [HttpGet("")]
        public IEnumerable<VersusDTO> Get(int pageNumber, int pageSize)
        {
            var versus = _versusService.GetAll(pageNumber, pageSize);
            var versusList = _mapper.Map<IEnumerable<VersusDTO>>(versus);
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
        public IEnumerable<VersusDTO> GetVersusForHome(int pageNumber = 1, int pageSize = 6)
        {
            var versus = _versusService.GetVersusForHome(pageNumber, pageSize);
            var versusList = _mapper.Map<IEnumerable<VersusDTO>>(versus);
            return versusList;
        }
    }
}
