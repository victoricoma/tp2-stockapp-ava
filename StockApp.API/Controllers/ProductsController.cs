using Microsoft.AspNetCore.Mvc;
using StockApp.Application.DTOs;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces;

namespace StockApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        
        private readonly IProductRepository _productRepository;
        

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet("All")]
        [ResponseCache(Duration =50, Location =ResponseCacheLocation.Any, NoStore =false)]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll(int pageNumber=1, int pageSize = 10)
        {
            var products = await _productRepository.GetAllAsync(pageNumber, pageSize);
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            await _productRepository.AddAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if (product ==null)
            {
                return BadRequest();
            }
            await _productRepository.UpdateAsync(product);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product= _productRepository.GetById(id);
            if (product.Id==null)
            {
                return NotFound("product not found =(...");
            }
            await _productRepository.Remove(id);
            return NoContent();
        }
    }
}
