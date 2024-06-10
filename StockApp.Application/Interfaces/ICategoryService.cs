using StockApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetCategoryById(int? id);
        Task Add(CategoryDTO categoryDto);
        Task Update(CategoryDTO categoryDto);
        Task Remove(int? id);

    }
}
