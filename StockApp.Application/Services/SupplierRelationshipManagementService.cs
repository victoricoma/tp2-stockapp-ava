using StockApp.Application.DTOs;
using StockApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Services
{
    public class SupplierRelationshipManagementService : ISupplierRelationshipManagementService
    {
        public async Task<SupplierDTO> EvaluateSupplierAsync(int supplierId)
        {
             return await Task.FromResult(new SupplierDTO
            {
                Id = supplierId,
                Name = "Fornecedor Exemplo",
                EvaluationScore = 90
            });
        }

        public async Task RenewContractAsync(int supplierId)
        {  await Task.CompletedTask;
        }
    }
}