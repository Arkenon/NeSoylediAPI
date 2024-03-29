﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeSoyledi.Api.Models.DataTypeObjects;
using NeSoyledi.Business.Abstract;
using Newtonsoft.Json;
using System;
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
        public IEnumerable<DiscourseDTO> Get(int pageNumber=1, int pageSize=10)
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
        public IEnumerable<DiscourseForProfileDTO> GetDiscoursesByProfileId(int pageNumber, int pageSize, int profileId, string order, string startDate = "", string endDate = "")
        {
            var discourse = _discourseService.GetDiscoursesByProfileId(pageNumber, pageSize, profileId, order, startDate, endDate);
            var discourseList = _mapper.Map<IEnumerable<DiscourseForProfileDTO>>(discourse);
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

        [HttpGet("{userId}")]
        public IEnumerable<DiscourseForProfileDTO> GetDiscoursesByUserId(int pageNumber, int pageSize, int userId)
        {
            var discourse = _discourseService.GetDiscoursesByUserId(pageNumber, pageSize, userId);
            var discourseList = _mapper.Map<IEnumerable<DiscourseForProfileDTO>>(discourse);
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

        [HttpGet("{categoryId}")]
        public IEnumerable<DiscourseDTO> GetDiscoursesByCategoryId(int pageNumber, int pageSize, int categoryId)
        {
            var discourse = _discourseService.GetDiscoursesByCategoryId(pageNumber, pageSize, categoryId);
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

        [HttpGet("")]
        public IEnumerable<DiscourseDTO> GetDiscoursesForHome(int pageNumber = 1, int pageSize = 12)
        {
            var discourse = _discourseService.GetDiscoursesForHome(pageNumber, pageSize);
            var discourseList = _mapper.Map<IEnumerable<DiscourseDTO>>(discourse);
            return discourseList;
        }
    }
}
