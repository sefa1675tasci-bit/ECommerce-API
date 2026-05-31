using AutoMapper;
using ECommerceApi.DTOs;
using ECommerceApi.Entities;
using ECommerceApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(
            IProductService productService,
            IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();

            var result = _mapper.Map<List<ProductDto>>(products);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            var result = _mapper.Map<ProductDto>(product);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var categoryExists =
                await _productService.CategoryExistsAsync(dto.CategoryId);

            if (!categoryExists)
            {
                return BadRequest("Kategori bulunamadı.");
            }

            var product = _mapper.Map<Product>(dto);

            var createdProduct =
                await _productService.AddAsync(product);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdProduct.Id },
                _mapper.Map<ProductDto>(createdProduct));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            UpdateProductDto dto)
        {
            var product =
                await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Stock = dto.Stock;
            product.CategoryId = dto.CategoryId;

            await _productService.UpdateAsync(product);

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string search)
        {
            var products = await _productService.SearchAsync(search);

            var result = _mapper.Map<List<ProductDto>>(products);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product =
                await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            await _productService.DeleteAsync(product);

            return Ok("Ürün silindi.");
        }
    }
}