using System;

namespace StockApp.Application.Interfaces
{
    public interface IMfaService
    {
        string GenerateOtp();  
        bool ValidateOtp(string userOtp, out string storedOtp);  
    }
}

