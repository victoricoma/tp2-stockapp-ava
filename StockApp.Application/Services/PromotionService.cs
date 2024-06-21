using StockApp.Application.Interfaces;
using System;
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
            if (startDate >= endDate)
            {
                throw new ArgumentException("A data de início da promoção deve ser anterior à data de término.");
            }

            if (discountPercentage <= 0 || discountPercentage > 100)
            {
                throw new ArgumentException("A porcentagem de desconto deve estar entre 0 e 100.");
            }

            decimal discount = CalculateDiscount(discountPercentage);

            var promotion = new Promotion(name, discountPercentage, startDate, endDate, string.Empty, discount);
            _promotionRepository.Add(promotion);
        }

        private decimal CalculateDiscount(decimal discountPercentage)
        {
            return discountPercentage / 100m;
        }
    }
}
