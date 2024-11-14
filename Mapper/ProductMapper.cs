using CNLTHD.DTO;
using CNLTHD.Models;

namespace CNLTHD.Mapper
{
    public static class ProductMapper
    {
        public static ProductDTO ToProductDTO(this Product product) {
            return new ProductDTO {
                CategoryId = product.CategoryId,
                Name = product.Name,
                Description = product.Description,
                ImageURL = product.ImageUrl,
                CategoryDTO = product.Category.ToCategoryDTO(),
                SupplierDTO = product.Supplier.ToSupplierDTO(),
            };
        }

        public static CategoryDto ToCategoryDTO(this Category category)
        {
            return new CategoryDto
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
            };
        }

        public static SupplierDTO ToSupplierDTO(this Supplier supplier)
        {
            return new SupplierDTO
            {
                SupplierId = supplier.SupplierId,
                Name = supplier.Name,
                Address = supplier.Address,
                Email = supplier.Email,
                Phone = supplier.Phone,
            };
        }
    }
}
