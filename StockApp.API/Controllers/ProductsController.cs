using Microsoft.AspNetCore.Mvc;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces;
using StockApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IInventoryService _inventoryService;

        public ProductsController(IProductRepository productRepository, IInventoryService inventoryService)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _inventoryService = inventoryService ?? throw new ArgumentNullException(nameof(inventoryService));
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetProducts();
            return View(products);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.Create(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
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
            return View(product);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _productRepository.GetById(id);
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
    }
}
