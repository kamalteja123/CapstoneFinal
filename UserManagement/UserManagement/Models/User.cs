using System.ComponentModel.DataAnnotations;
namespace UserManagement.Models
{
    public class User:IEquatable<User>
    {
        [Key] 
        public int UId { get; set; }
        public string Email { get; set; } = string.Empty;
        public byte[] Password { get; set; }
        public byte[] Key { get; set; }
        public string Role { get; set; } = "Patient";
        public string Status { get; set; } = string.Empty;
        public bool Equals(User? other)
        {
            if (other == null) return false;
            return UId == other.UId;
        }
    }
}
