using StockApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockApp.Domain.Interfaces
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllAsync();
        Task<Supplier> GetByIdAsync(int id);
        Task AddAsync(Supplier supplier);
        Task UpdateAsync(Supplier supplier);
        Task DeleteAsync(int id);
        Task<IEnumerable<Supplier>> SearchAsync(string name, string contactEmail);
    }
}
