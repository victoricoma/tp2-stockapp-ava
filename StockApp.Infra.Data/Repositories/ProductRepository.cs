using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces;
using StockApp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
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

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public string EscapeForCsv(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            if (value.Contains("\""))
                value = value.Replace("\"", "\"\"");

            if (value.Contains(","))
                value = $"\"{value}\"";

            return value;
        }

        public async Task<IEnumerable<Product>> SearchAsync(string query, string sortBy, bool descending)
        {
            IQueryable<Product> queryable = _context.Products;

            if (!string.IsNullOrEmpty(query))
            {
                queryable = queryable.Where(p =>
                    p.Name.Contains(query) ||
                    p.Description.Contains(query));
            }

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.ToLower())
                {
                    case "name":
                        queryable = descending ? queryable.OrderByDescending(p => p.Name) : queryable.OrderBy(p => p.Name);
                        break;
                    case "price":
                        queryable = descending ? queryable.OrderByDescending(p => p.Price) : queryable.OrderBy(p => p.Price);
                        break;
                    case "stock":
                        queryable = descending ? queryable.OrderByDescending(p => p.Stock) : queryable.OrderBy(p => p.Stock);
                        break;
                    default:
                        queryable = descending ? queryable.OrderByDescending(p => p.Id) : queryable.OrderBy(p => p.Id);
                        break;
                }
            }
            else
            {
                queryable = queryable.OrderBy(p => p.Id);
            }

            return await queryable.ToListAsync();
        }
    }
}
