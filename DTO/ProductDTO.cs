using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CNLTHD.DTO
{
    public class ProductDTO
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
        public string ImageURL { get; set; }
        public SupplierDTO? SupplierDTO { get; set; }
        public CategoryDto? CategoryDTO { get; set; }
    }

    public class CreateProductDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; } = null!;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative.")]
        public int? Stock { get; set; }

        [Required(ErrorMessage = "CategoryId is required.")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "SupplierId is required.")]
        public int? SupplierId { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        public IFormFile? Image { get; set; }
    }

    public class UpdateProductDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; } = null!;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative.")]
        public int? Stock { get; set; }

        public int? CategoryId { get; set; }

        public int? SupplierId { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        public IFormFile? Image { get; set; }
    }
}