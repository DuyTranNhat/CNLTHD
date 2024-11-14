using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNLTHD.DTO;
using CNLTHD.Models;

namespace CNLTHD.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO?> GetProductByIdAsync(int id);
        Task<ProductDTO> CreateProductAsync(CreateProductDto productDto);
        Task<ProductDTO?> UpdateProductAsync(int id, UpdateProductDto productDto);
        Task<bool> DeleteProductAsync(int id);
    }
}