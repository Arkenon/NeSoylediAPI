using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeSoyledi.Api.Models.DataTypeObjects;
using NeSoyledi.Business.Abstract;
using NeSoyledi.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeSoyledi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet("")]
        public IEnumerable<CategoryDTO> Get(int pageNumber = 1, int pageSize = 50)
        {
            var category = _categoryService.GetAll(pageNumber,pageSize);
            var categoryList = _mapper.Map<IEnumerable<CategoryDTO>>(category);
            var metadata = new
            {
                category.TotalCount,
                category.PageSize,
                category.CurrentPage,
                category.TotalPages,
                category.HasNext,
                category.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return categoryList;
        }

        [HttpGet("{id}")]
        public async Task<CategoryDTO> GetById(int id)
        {
            var _category = await _categoryService.GetById(id);
            var category = _mapper.Map<CategoryDTO>(_category);   
            return category;
        }

        [HttpPost("")]
        public async Task<CategoryDTO> Create(SaveCategoryDTO entity)
        {
            var category = _mapper.Map<Category>(entity);
            await _categoryService.Create(category);
            return await GetById(category.Id);
        }

        [HttpPut("{id}")]
        public async Task<CategoryDTO> Update(int id, SaveCategoryDTO entity)
        {
            var category = _mapper.Map<Category>(entity);
            await _categoryService.Update(id, category);
            return await GetById(category.Id);
        }
    }
}
