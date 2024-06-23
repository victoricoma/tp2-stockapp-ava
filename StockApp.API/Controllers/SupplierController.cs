using Microsoft.AspNetCore.Mvc;
using StockApp.Application.Interfaces;

namespace StockApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierRelationshipManagementService _supplierService;

        public SupplierController(ISupplierRelationshipManagementService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet("{supplierId}/evaluate")]
        public async Task<IActionResult> EvaluateSupplier(int supplierId)
        {
            var result = await _supplierService.EvaluateSupplierAsync(supplierId);
            return Ok(result);
        }

        [HttpPost("{supplierId}/renew")]
        public async Task<IActionResult> RenewContract(int supplierId)
        {
            await _supplierService.RenewContractAsync(supplierId);
            return NoContent();
        }
    }
}