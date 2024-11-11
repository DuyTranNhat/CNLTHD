using System.ComponentModel.DataAnnotations;

namespace CNLTHD.DTO
{
    public class CreateUserDto
    {
        [Required]
        public string FullName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [RegularExpression(@"^(Admin|Customer)$", ErrorMessage = "Role must be either 'Admin' or 'Customer'")]
        public string? Role { get; set; }
        [Required]
        [MaxLength(15)]
        [Phone]
        public string Phone { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string Address { get; set; } = null!;

    }
    public class LoginUserDto
    {
        [Required(ErrorMessage = "Username is required!")]
        public string Username { get; set; } = null!;
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; } = null!;
    }
}
