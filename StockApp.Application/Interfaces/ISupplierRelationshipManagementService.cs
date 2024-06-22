using StockApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Interfaces
{
    public interface ISupplierRelationshipManagementService
    {
        Task<SupplierDTO> EvaluateSupplierAsync(int supplierId);
        Task RenewContractAsync(int supplierId);
    }
}
