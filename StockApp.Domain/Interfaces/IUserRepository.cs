using StockApp.Domain.Entities;
using System.Threading.Tasks;

namespace StockApp.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAsync(string username);
        Task AddAsync(User user);
    }
}
