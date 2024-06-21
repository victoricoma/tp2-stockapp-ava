using StockApp.Application.Interfaces;
using StockApp.Application.DTOs;
using StockApp.Infra.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace StockApp.API.Controllers
{
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _promotionService;
        private readonly IDiscountService _discountService;

        public PromotionController(IPromotionService promotionService, IDiscountService discountService)
        {
            _promotionService = promotionService;
            _discountService = discountService;
        }
    }
}
