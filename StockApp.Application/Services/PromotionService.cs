using StockApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces;

namespace StockApp.Application.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _promotionRepository;
        
        public PromotionService(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        public void CreatePromotion(string name, decimal discountPercentage, DateTime startDate, DateTime endDate)
        {
            var promotion = new Promotion(name, discountPercentage, startDate, endDate);
            _promotionRepository.Add(promotion);
        }
    }
}
