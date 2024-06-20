using Microsoft.AspNetCore.Mvc;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces;
using StockApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StockApp.Application.DTOs;
using StockApp.Application.Services;

namespace StockApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IInventoryService _inventoryService;
        private readonly IProductService _productService;

        public ProductsController(IProductRepository productRepository, IInventoryService inventoryService, IProductService productService)
        {
            _productRepository = productRepository;
            _inventoryService = inventoryService;
            _productService = productService;
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

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            return Ok(product);
        }

        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetProducts();
            return Ok(products);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetProductById(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return Ok();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.Create(product);
                return RedirectToAction(nameof(Index));
            }
            return Ok(product);
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetProductById(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _productRepository.Update(product);
                return RedirectToAction(nameof(Index));
            }
            return Ok(product);
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetProductById(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product != null)
            {
                await _productRepository.Remove(product);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("low-stock")]
        public async Task<ActionResult<IEnumerable<Product>>> GetLowStock([FromQuery] int threshold)
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
                await _inventoryService.ReplenishStockAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error replenishing stock: " + ex.Message);
                return RedirectToAction(nameof(Index));
            }

        }

        [HttpGet("filtered")]
        public async Task<ActionResult<IEnumerable<Product>>> GetFiltered([FromQuery] string name, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
        {
            var products = await _productRepository.GetFilteredAsync(name, minPrice, maxPrice);
            return Ok(products);
        }

        [HttpGet("all")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll(int pageNumber = 1, int pageSize = 10)
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
                ModelState.AddModelError(string.Empty, "Error exporting products: " + ex.Message);
                return RedirectToAction(nameof(Index));
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
        public async Task<ActionResult<IEnumerable<Product>>> Search([FromQuery] string query, [FromQuery] string sortBy, [FromQuery] bool descending)
        {
            var products = await _productRepository.SearchAsync(query, sortBy, descending);
            return Ok(products);

        }

        [HttpPost("{id}/upload-image")]
        public async Task<IActionResult> UploadImage(int id, IFormFile image)
        {
            try
            {
                if (image == null || image.Length == 0)
                {
                    return BadRequest("Invalid image.");
                }

                if (!IsImageFile(image.FileName))
                {
                    return BadRequest("Unsupported file format. Only JPG, JPEG, and PNG files are allowed.");
                }

                var filePath = Path.Combine("wwwroot/images", $"{id}.jpg");

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                var product = await _productRepository.GetProductById(id);
                if (product == null)
                {
                    return NotFound("Product not found.");
                }

                product.Image = $"{id}.jpg";
                await _productRepository.Update(product);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private bool IsImageFile(string fileName)
        {
            string ext = Path.GetExtension(fileName).ToLowerInvariant();
            return ext == ".jpg" || ext == ".jpeg" || ext == ".png";
        }

    }
}
