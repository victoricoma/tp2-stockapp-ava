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
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        Product Create(Product product);

        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetById(int? id);
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<Product> Remove(Product product);


        Task GetAllAsync(int pageNumber);
        Task GetByIdAsync(int id);
        Task AddAsync(Product product);
        IEnumerable<Product> GetAll();
        Task UpdateAsync(Product product);
    }
}
