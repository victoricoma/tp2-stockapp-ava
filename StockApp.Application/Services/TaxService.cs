using StockApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Services
{
    public class TaxService : ITaxService
    {
        public decimal CalculateTax(decimal amount)
        {
            return amount * 0.15M; 
        }
    }

}
