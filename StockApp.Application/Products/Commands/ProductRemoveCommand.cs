using MediatR;
using StockApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Products.Commands
{
    public class ProductRemoveCommand : IRequest<Product>
    {
        public int Id { get; set; }
        public ProductRemoveCommand(int id) 
        {
            Id = id;
        }
    }
}
