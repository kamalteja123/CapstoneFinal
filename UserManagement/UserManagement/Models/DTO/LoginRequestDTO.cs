using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models.DTO
{
    public class LoginRequestDTO
    {
        [Required(ErrorMessage = "Email cannot be empty")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is manditory")]
        public string Password { get; set; } = string.Empty;
       
    }
}
