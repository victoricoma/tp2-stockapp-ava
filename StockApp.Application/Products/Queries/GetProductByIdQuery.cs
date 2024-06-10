using MediatR;
using StockApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
