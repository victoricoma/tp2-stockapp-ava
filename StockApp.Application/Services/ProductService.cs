using AutoMapper;
using StockApp.Application.DTOs;
using StockApp.Application.Interfaces;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public async Task Add(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.Create(productEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsEntity = await _productRepository.GetProducts();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task<ProductDTO> GetProductById(int? id)
        {
            var productEntity = _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task Remove(int? id)
        {
            var productEntity = _productRepository.GetById(id).Result;
            await _productRepository.Remove(productEntity);
        }

        public async Task Update(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.Update(productEntity);
        }
    }
}
