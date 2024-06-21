using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces;
using StockApp.Infra.Data.Context;

namespace StockApp.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public async Task<IEnumerable<Product>> GetByIdsAsync(IEnumerable<int> ids)
        {
           return await _context.Products.Where(p => ids.Contains(p.Id)).ToListAsync();
        }

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task BulkUpdateAsync(List<Product> products)
        {
            if (products == null || !products.Any())
                throw new ArgumentException("Product list cannot be null or empty", nameof(products));

            foreach (var product in products)
            {
                var existingProduct = await _context.Products.FindAsync(product.Id);
                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.Description = product.Description;
                    existingProduct.Price = product.Price;
                    existingProduct.Stock = product.Stock;
                    existingProduct.Image = product.Image;
                }
            }
        }

        public async Task<IEnumerable<Product>> GetLowStockAsync(int threshold)
        {
            return await _context.Products
                .Where(p => p.Stock < threshold)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Product> Create(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetProductById(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "Id cannot be null.");
            }

            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                throw new KeyNotFoundException($"Product with id {id} not found.");
            }

            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> Remove(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _context.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _context.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetFilteredAsync(string name, decimal? minPrice, decimal? maxPrice)
        {
            IQueryable<Product> query = _context.Products;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchAsync(string query, string sortBy, bool descending)
        {
            IQueryable<Product> queryResult = _context.Products;

            if (!string.IsNullOrEmpty(query))
            {
                queryResult = queryResult.Where(p => p.Name.Contains(query));
            }

            switch (sortBy?.ToLower())
            {
                case "name":
                    queryResult = descending ? queryResult.OrderByDescending(p => p.Name) : queryResult.OrderBy(p => p.Name);
                    break;
                case "price":
                    queryResult = descending ? queryResult.OrderByDescending(p => p.Price) : queryResult.OrderBy(p => p.Price);
                    break;
                default:
                    break;
            }

            return await queryResult.ToListAsync();
        }

        public Task AddAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
