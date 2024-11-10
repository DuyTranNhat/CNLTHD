using Microsoft.SqlServer.Server;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

namespace CNLTHD.DTO
{
    public class SupplierDTO
    {
        public int SupplierId { get; set; }

        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }
    }

    public class CreateSupplierDTO
    {
        [Required(ErrorMessage = "Supplier's name cannot be empty!")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Address name cannot be empty!")]
        public string? Address { get; set; }


        [Required(ErrorMessage = "Phone name cannot be empty!")]
        [Phone(ErrorMessage = "The phone number is not in the correct format!")]
        public string? Phone { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "The Email Address number is not in the correct format!")]
        public string? Email { get; set; }
    }

    public class UpdateSupplierDTO
    {
        [Required(ErrorMessage = "Supplier's name cannot be empty!")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Address name cannot be empty!")]
        public string? Address { get; set; }


        [Required(ErrorMessage = "Phone name cannot be empty!")]
        [Phone(ErrorMessage = "The phone number is not in the correct format!")]
        public string? Phone { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "The Email Address number is not in the correct format!")]
        public string? Email { get; set; }
    }
}
