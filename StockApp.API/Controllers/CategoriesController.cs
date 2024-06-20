using Microsoft.AspNetCore.Mvc;
using StockApp.Application.DTOs;
using StockApp.Application.Interfaces;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductRepository _productRepository;

        public CategoriesController(ICategoryService categoryService, IProductRepository productRepository)
        {
            _categoryService = categoryService;
            _productRepository = productRepository;
        }

        [HttpGet(Name = "GetCategories")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategories();
            if (categories == null || !categories.Any())
            {
                return NotFound("Categories not found");
            }
            return Ok(categories);
        }


        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound("Category not found");
            }
            return Ok(category);
        }

        [HttpPost(Name = "CreateCategory")]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                return BadRequest("Invalid data");
            }

            await _categoryService.Add(categoryDTO);

            return CreatedAtRoute("GetCategory", new { id = categoryDTO.Id }, categoryDTO);
        }

        [HttpPut("{id:int}", Name = "UpdateCategory")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (id != categoryDTO.Id)
            {
                return BadRequest("Inconsistent ID");
            }
            if (categoryDTO == null)
            {
                return BadRequest("Update data invalid");
            }

            await _categoryService.Update(categoryDTO);

            return Ok(categoryDTO);
        }

        [HttpDelete("{id:int}", Name = "DeleteCategory")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound("Category not found");
            }

            await _categoryService.Remove(id);

            return Ok(category);
        }

        [HttpGet("products", Name = "GetAllProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _productRepository.GetProducts();
            return Ok(products);
        }

        [HttpGet("pages", Name = "GetAllPages")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var products = await _productRepository.GetAllAsync(pageNumber, pageSize);
            return Ok(products);
        }

        [HttpPut("bulk-update", Name = "BulkUpdateProducts")]
        public async Task<IActionResult> BulkUpdate([FromBody] List<Product> products)
        {
            if (products == null || !products.Any())
            {
                return BadRequest("Invalid product data");
            }

            await _productRepository.BulkUpdateAsync(products);
            return NoContent();
        }
    }
}
