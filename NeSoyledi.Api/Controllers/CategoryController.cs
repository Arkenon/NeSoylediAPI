using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeSoyledi.Api.Models.DataTypeObjects;
using NeSoyledi.Business.Abstract;
using NeSoyledi.Entities;
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
        public IEnumerable<CategoryDTO> GetAll()
        {
            var category = _categoryService.GetAll();
            var categoryList = _mapper.Map<IEnumerable<CategoryDTO>>(category);
            return categoryList;
        }

        [HttpGet("{id}/discourses", Name = "GetWithDiscourses")]
        public async Task<CategoryWithDiscourseDTO> GetWithDiscourses(int id)
        {
            var category = await _categoryService.GetWithDiscourses(id);
            var response = _mapper.Map<CategoryWithDiscourseDTO>(category);
            return response;
        }

        [HttpGet("{id}/versus", Name = "GetWithVersus")]
        public async Task<CategoryWithVersusDTO> GetWithVersus(int id)
        {
            var category = await _categoryService.GetWithVersus(id);
            var response = _mapper.Map<CategoryWithVersusDTO>(category);
            return response;
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
