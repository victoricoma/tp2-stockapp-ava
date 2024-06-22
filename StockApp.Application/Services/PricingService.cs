using Newtonsoft.Json;
using StockApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Services
{
    public class PricingService : IPricingService
    {
        private readonly HttpClient _httpClient;

        public PricingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<decimal> GetProductPriceAsync(string productId)
        {
            var response = await _httpClient.GetAsync($"products/{productId}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var price = JsonConvert.DeserializeObject<decimal>(content);

            return price;
        }
    }

}
