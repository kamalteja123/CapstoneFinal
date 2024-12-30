using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Models
{
   

    public class Patient:IEquatable<Patient>
    {
        [Key]
        public int PatientId { get; set; }
        public string PatientName { get; set; }=string.Empty;
        public int Age { get; set; }
  
        public string Gender { get; set; } = string.Empty; 
      
        public string Address { get; set; } = string.Empty;
        //public string Role { get; set; } = string.Empty;
        [ForeignKey("User")] 
        public int UId { get; set; }
        public User? User { get; set; } // Navigation property
        public bool Equals(Patient? other)
        {
            if (other == null) return false;
            return PatientId == other.PatientId;
        }
    }


}
