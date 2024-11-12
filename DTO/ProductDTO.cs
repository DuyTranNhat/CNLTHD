using System;
using System.Collections.Generic;
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
        public IFormFile? Image { get; set; }
    }

    public class CreateProductDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
        public string? ImageUrl { get; set; }
    }

    public class UpdateProductDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
        public string? ImageUrl { get; set; }
    }
}