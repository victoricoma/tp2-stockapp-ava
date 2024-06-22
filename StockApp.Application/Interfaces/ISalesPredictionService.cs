using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Interfaces
{
    public interface ISalesPredictionService
    {
        double PredictSales(int productId, int month, int year);
    }
}
