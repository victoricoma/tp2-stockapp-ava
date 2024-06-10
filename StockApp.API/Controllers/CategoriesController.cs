using Microsoft.AspNetCore.Mvc;
using StockApp.Application.DTOs;
using StockApp.Application.Interfaces;

namespace StockApp.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet(Name ="GetCategories")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get() 
        {
            var categories = await _categoryService.GetCategories();
            if(categories== null)
            {
                return NotFound("Categories not found");
            }
            return Ok(categories);
        }
        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if(category== null)
            {
                return NotFound("Category not Found");
            }
            return Ok(category);
        }
        [HttpPost(Name ="Create Category")]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            if(categoryDTO == null)
            {
                return BadRequest("Invalid Data");
            }
            await _categoryService.Add(categoryDTO);

            return new CreatedAtRouteResult("GetCategory", 
                new { id = categoryDTO.Id }, categoryDTO);
        }

        [HttpPut(Name ="Update Category")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if(id != categoryDTO.Id)
            {
                return BadRequest("Inconsisted Id");
            }
            if(categoryDTO == null)
            {
                return BadRequest("Update Data Invalid");
            }

            await _categoryService.Update(categoryDTO);

            return Ok(categoryDTO);
        }

        [HttpDelete("{id:int}", Name ="Delete Category")]
        public async Task<ActionResult<CategoryDTO>> Detele(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if(category == null) 
            {
                return NotFound("Category not found");
            }

            await _categoryService.Remove(id);

            return Ok(category);
        }
    }
}
