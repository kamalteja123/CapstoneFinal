using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Models
{
    public class Doctor: IEquatable<Doctor>
    {
        [Key]
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty; 
        public string Qualifications { get; set; } = string.Empty; 
        public int YearsOfExperience { get; set; }

       
        [ForeignKey("User")] 
        public int UId { get; set; }
        public User? User { get; set; } // Navigation property
        public bool Equals(Doctor? other)
        {
            if (other == null) return false;
            return DoctorId == other.DoctorId;
        }
    }
}
