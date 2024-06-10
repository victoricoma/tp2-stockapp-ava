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
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository,IMapper mapper) 
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task Add(CategoryDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.Create(categoryEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = await _categoryRepository.GetCategories();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetCategoryById(int? id)
        {
            var categoryEntity = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task Remove(int? id)
        {
            var categoryEntity = _categoryRepository.GetById(id).Result;
            await _categoryRepository.Remove(categoryEntity);
        }

        public async Task Update(CategoryDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.Update(categoryEntity);
        }
    }
}
