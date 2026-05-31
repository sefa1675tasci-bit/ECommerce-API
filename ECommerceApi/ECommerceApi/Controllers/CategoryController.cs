using AutoMapper;
using ECommerceApi.DTOs;
using ECommerceApi.Entities;
using ECommerceApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(
            ICategoryService categoryService,
            IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();

            return Ok(_mapper.Map<List<CategoryDto>>(categories));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);

            await _categoryService.AddAsync(category);

            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            UpdateCategoryDto dto)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            category.Name = dto.Name;

            await _categoryService.UpdateAsync(category);

            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            await _categoryService.DeleteAsync(category);

            return Ok("Kategori silindi.");
        }
    }
}