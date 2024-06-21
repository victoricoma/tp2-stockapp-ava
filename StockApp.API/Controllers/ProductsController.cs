using Microsoft.AspNetCore.Mvc;
using StockApp.Application.DTOs;
using StockApp.Application.Interfaces;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
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

        public ProductsController(
            IProductRepository productRepository,
            IReviewService reviewService,
            IReviewRepository reviewRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _reviewService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));
            _reviewRepository = reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository));
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

        [HttpGet("low-stock")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetLowStock([FromQuery] int threshold)
        {
            var products = await _productRepository.GetLowStockAsync(threshold);
            return Ok(products);
        }

        [HttpPost("replenish-stock")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReplenishStock()
        {
            try
            {
                // await _inventoryService.ReplenishStockAsync();
                return Ok("Stock replenished successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error replenishing stock: " + ex.Message);
            }
        }

        [HttpGet("filtered")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetFiltered([FromQuery] string name, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
        {
            var products = await _productRepository.GetFilteredAsync(name, minPrice, maxPrice);
            return Ok(products);
        }

        [HttpGet("all")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            var products = await _productRepository.GetAllAsync(pageNumber, pageSize);
            return Ok(products);
        }

        [HttpGet("export")]
        public async Task<IActionResult> ExportToCsv()
        {
            try
            {
                var products = await _productRepository.GetProducts();
                var csv = new StringBuilder();
                csv.AppendLine("Id,Name,Description,Price,Stock");

                foreach (var product in products)
                {
                    csv.AppendLine($"{product.Id},{EscapeForCsv(product.Name)},{EscapeForCsv(product.Description)},{product.Price},{product.Stock}");
                }

                return File(Encoding.UTF8.GetBytes(csv.ToString()), "text/csv", "products.csv");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error exporting products: " + ex.Message);
            }
        }

        private string EscapeForCsv(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            if (value.Contains("\""))
                value = value.Replace("\"", "\"\"");

            if (value.Contains(","))
                value = $"\"{value}\"";

            return value;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Search([FromQuery] string query, [FromQuery] string sortBy, [FromQuery] bool descending)
        {
            var products = await _productRepository.SearchAsync(query, sortBy, descending);
            return Ok(products);
        }

        [HttpPost("{productId}/review")]
        public async Task<IActionResult> AddReview(int productId, [FromBody] Review review)
        {
            try
            {
                if (review.Rating < 1 || review.Rating > 5)
                {
                    return BadRequest("Rating must be between 1 and 5.");
                }

                review.ProductId = productId;
                review.Date = DateTime.Now;

                await _reviewRepository.AddAsync(review);

                return Ok(review);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error adding review: " + ex.Message);
            }
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

        //[HttpPost("compare", Name = "CompareProducts")]
        //public async Task<ActionResult<IEnumerable<Product>>> CompareProducts([FromBody] List<int> productIds)
        //{
        //    var products = await _productRepository.GetByIdsAsync(productIds);
        //    if (products == null || !products.Any())
        //    {
        //        return NotFound("Products not found.");
        //    }
        //    return Ok(products);
        //}

        //[HttpPost("webhook")]
        //public async Task<IActionResult> Webhook([FromBody] WebhookDTO webhookDTO)
        //{
        //    if (webhookDTO.EventType == "ProductCreated")
        //    {
        //        await NotifyExternalSystems(webhookDTO.EventData);
        //    }
        //    else if (webhookDTO.EventType == "CategoryUpdated")
        //    {
        //        await NotifyExternalSystems(webhookDTO.EventData);
        //    }

        //    return Ok();
        //}

        private async Task NotifyExternalSystems(string eventData)
        {

        }
    }
}
