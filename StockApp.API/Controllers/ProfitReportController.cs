using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient; // Adicionar diretiva 'using' necessária
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace StockApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfitReportController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ProfitReportController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("profit-report")]
        public async Task<IActionResult> GetProfitReport()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new MySqlCommand("GetProfitReport", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        var profitReport = new List<ProfitReportDto>();

                        while (await reader.ReadAsync())
                        {
                            profitReport.Add(new ProfitReportDto
                            {
                                ProductName = reader.GetString("Name"),
                                TotalProfit = reader.GetDecimal("TotalProfit")
                            });
                        }

                        return Ok(profitReport);
                    }
                }
            }
        }
    }

    public class ProfitReportDto
    {
        public string ProductName { get; set; }
        public decimal TotalProfit { get; set; }
    }
}
