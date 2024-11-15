﻿using CNLTHD.DTO;

namespace CNLTHD.Service.IService
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto categoryDto);
        Task<CategoryDto> UpdateCategoryAsync(int id, UpdateCategoryDto categoryDto);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
