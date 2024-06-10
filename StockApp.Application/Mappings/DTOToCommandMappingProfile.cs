using AutoMapper;
using StockApp.Application.DTOs;
using StockApp.Application.Products.Commands;


namespace StockApp.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
