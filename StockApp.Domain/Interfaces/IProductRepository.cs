using StockApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Product>> GetAllAsync(int pageNumber, int pageSize);
        Task<IEnumerable<Product>> GetLowStockAsync(int threshold);
        Task<IEnumerable<Product>> GetFilteredAsync(string name, decimal? minPrice, decimal? maxPrice);
        Task<IEnumerable<Product>> SearchAsync(string query, string sortBy, bool descending);
        Task<IEnumerable<Product>> GetByIdsAsync(IEnumerable<int> ids);

        Task<IEnumerable<Product>> GetAll(int pageNumber, int pageSize);
        Task BulkUpdateAsync(List<Product> products);

        Task<Product> GetProductById(int? id);
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<Product> Remove(Product product);
        Task AddAsync(Product product);
        Task Remove(int id);
        Task GetById(int id);
    }
}
