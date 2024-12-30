using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models.DTO
{
    public class UserRegisterRequestDTO
    {
       
        [Required(ErrorMessage = "Email cannot be empty")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is manditory")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; } = string.Empty;
        public long PhoneNumber { get; set; }
        public string Role { get; set; } = "Patient";
    }
}
