using Microsoft.AspNetCore.Mvc;
using StockApp.Application.Interfaces;

namespace StockApp.API.Controllers
{
    public class InventoryController : ControllerBase
    {
        private readonly IJustInTimeInventoryService _jitInventoryService;

        public InventoryController(IJustInTimeInventoryService jitInventoryService)
        {
            _jitInventoryService = jitInventoryService;
        }

        [HttpPost("optimize-inventory")]
        public async Task<IActionResult> OptimizeInventory()
        {
            try
            {
                await _jitInventoryService.OptimizeInventoryAsync();
                return Ok("Inventário otimizado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao otimizar inventário: {ex.Message}");
            }
        }
    }

}
