using Newtonsoft.Json;
using StockApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Services
{
    public class ReviewService : IReviewService
    {
        public async Task AddReview(int productId, int rating, string comment)
        {
            try
            {
                var apiUrl = $"{productId}/review";
                var content = new StringContent(JsonConvert.SerializeObject(new { rating, comment }), Encoding.UTF8, "application/json");

                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Avaliação adicionada com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine($"Erro ao adicionar avaliação: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar avaliação: {ex.Message}");
            }
        }
    }
}
