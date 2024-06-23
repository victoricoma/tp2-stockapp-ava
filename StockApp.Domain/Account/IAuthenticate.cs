using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> RegisterUser(string email, string password);
        Task Logout();
    }
}
