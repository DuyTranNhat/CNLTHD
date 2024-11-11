using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNLTHD.DTO;

namespace CNLTHD.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync();
        Task<ProductDTO?> GetByIdAsync(int id);
        Task<ProductDTO> CreateAsync(CreateProductDto createProductDto);
        Task<ProductDTO?> UpdateAsync(int id, UpdateProductDto updateProductDto);
        Task<bool> DeleteAsync(int id);
    }
}