using System.ComponentModel.DataAnnotations;

namespace CNLTHD.DTO
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string Name { get; set; } = null!;
    }

    public class UpdateCategoryDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string Name { get; set; } = null!;
    }

    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
    }
}
