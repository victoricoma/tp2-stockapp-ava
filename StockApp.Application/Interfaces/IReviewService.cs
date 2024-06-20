using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Interfaces
{
    public interface IReviewService
    {
        Task AddReview(int productId, int rating, string comment);
    }
}
