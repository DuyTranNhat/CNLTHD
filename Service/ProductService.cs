using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNLTHD.DTO;
using CNLTHD.Models;
using CNLTHD.Repository.IRepository;
using CNLTHD.Service.IService;

namespace CNLTHD.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            return products.Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                CategoryId = p.CategoryId,
                SupplierId = p.SupplierId,
                ImageUrl = p.ImageUrl
            });
        }

        public async Task<ProductDTO?> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return null;

            return new ProductDTO
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId,
                SupplierId = product.SupplierId,
                ImageUrl = product.ImageUrl
            };
        }

        public async Task<ProductDTO> CreateAsync(CreateProductDto createProductDto)
        {
            var product = new Product
            {
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                Stock = createProductDto.Stock,
                CategoryId = createProductDto.CategoryId,
                SupplierId = createProductDto.SupplierId,
                ImageUrl = createProductDto.ImageUrl
            };

            await _repository.AddAsync(product);
            return await GetByIdAsync(product.ProductId);
        }

        public async Task<ProductDTO?> UpdateAsync(int id, UpdateProductDto updateProductDto)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return null;

            product.Name = updateProductDto.Name;
            product.Description = updateProductDto.Description;
            product.Price = updateProductDto.Price;
            product.Stock = updateProductDto.Stock;
            product.CategoryId = updateProductDto.CategoryId;
            product.SupplierId = updateProductDto.SupplierId;
            product.ImageUrl = updateProductDto.ImageUrl;

            await _repository.UpdateAsync(product);
            return await GetByIdAsync(product.ProductId);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}