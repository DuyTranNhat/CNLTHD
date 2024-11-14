using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNLTHD.DTO;
using CNLTHD.Mapper;
using CNLTHD.Models;
using CNLTHD.Repository.IRepository;
using CNLTHD.Service.IService;

namespace CNLTHD.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment _env;

        public ProductService(IProductRepository repository, IWebHostEnvironment env)
        {
            _productRepository = repository;
            _env = env;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var product = await _productRepository.GetAllAsync();
            var rs = product.Select(p => p.ToProductDTO()).ToList();
            return rs;
        }

        public async Task<ProductDTO?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return null;
            return product?.ToProductDTO();
        }

        public async Task<ProductDTO> CreateProductAsync(CreateProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Stock = productDto.Stock,
                CategoryId = productDto.CategoryId,
                SupplierId = productDto.SupplierId
            };

            if (productDto.Image != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
                Directory.CreateDirectory(uploadsFolder);
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + productDto.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await productDto.Image.CopyToAsync(fileStream);
                }

                product.ImageUrl = "/uploads/" + uniqueFileName;
            }

            await _productRepository.AddAsync(product);

            var rs = await GetProductByIdAsync(product.ProductId);

            return rs;
        }

        public async Task<ProductDTO?> UpdateProductAsync(int id, UpdateProductDto productDto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return null;

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.Stock = productDto.Stock;
            product.CategoryId = productDto.CategoryId;
            product.SupplierId = productDto.SupplierId;

            if (productDto.Image != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
                Directory.CreateDirectory(uploadsFolder);
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + productDto.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await productDto.Image.CopyToAsync(fileStream);
                }

                product.ImageUrl = "/uploads/" + uniqueFileName;
            }

            await _productRepository.UpdateAsync(product);
            var rs = await GetProductByIdAsync(product.ProductId);
            return rs;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return false;

            if (product.ImageUrl != null)
            {
                string imagePath = Path.Combine(_env.WebRootPath, product.ImageUrl.TrimStart('/'));
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }
            }

            await _productRepository.DeleteAsync(id);
            return true;
        }
    }
}