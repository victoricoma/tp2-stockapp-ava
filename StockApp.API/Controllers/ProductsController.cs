using Microsoft.AspNetCore.Mvc;
using StockApp.Application.DTOs;
using StockApp.Application.Interfaces;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using System.Threading.Tasks;

namespace StockApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IReviewService _reviewService;
        private readonly IReviewRepository _reviewRepository;
        private readonly IDiscountService _discountService;


        public ProductsController(
            IProductRepository productRepository)

        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));

        }

        [HttpGet(Name = "GetProducts")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var products = await _productRepository.GetProducts();
            if (products == null)
            {
                return NotFound("Products not found");
            }
            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            return Ok(product);
        }


        [HttpGet("pages", Name = "GetAllPages")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var products = await _productRepository.GetAllAsync(pageNumber, pageSize);
            return Ok(products);
        }


        [HttpGet("all")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllAsync(int pageNumber = 1, int pageSize = 10)
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

        private object GetById()
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            await _productRepository.Update(product);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productRepository.Remove(id);
            return NoContent();
        }

        [HttpPost("compare", Name = "CompareProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> CompareProducts([FromBody] List<int> productIds)
        {
            var products = await _productRepository.GetByIdsAsync(productIds);
            if (products == null || !products.Any())
            {
                return NotFound("Products not found.");
            }
            return Ok(products);
        }
        private async Task NotifyExternalSystems(string eventData)
        {

        }

        [HttpPost("webhook")]
        public async Task<IActionResult> Webhook([FromBody] WebhookDTO webhookDTO)
        {
            if (webhookDTO.EventType == "ProductCreated")
            {
                await NotifyExternalSystems(webhookDTO.EventData);
            }
            else if (webhookDTO.EventType == "CategoryUpdated")
            {
                await NotifyExternalSystems(webhookDTO.EventData);
            }

            return Ok();
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

        [HttpPost("{productId}/review")]
        public async Task<IActionResult> AddReview(int productId, [FromBody] Review review)
        {
            try
            {
                if (review.Rating < 1 || review.Rating > 5)
                {
                    return BadRequest("A nota deve estar entre 1 e 5.");
                }

                review.ProductId = productId;
                review.Date = DateTime.Now;

                await _reviewRepository.AddAsync(review);

                return Ok(review);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao adicionar avaliação: " + ex.Message);
            }

        }
        public ProductsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet("calculate-discount")]
        public IActionResult CalculateDiscount(decimal price, decimal discountPercentage)
        {
            var discountedPrice = _discountService.ApplyDiscount(price, discountPercentage);
            return Ok(new { DiscountedPrice = discountedPrice });
        }
    }
}
