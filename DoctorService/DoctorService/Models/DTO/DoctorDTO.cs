namespace DoctorService.Models.DTO
{
    public class DoctorDTO 
    { 
        public int DoctorId { get; set; } 
        public string DoctorName { get; set; } = string.Empty; 
        public string Specialization { get; set; } = string.Empty; 
        public string Qualifications { get; set; } = string.Empty; 
        public int YearsOfExperience { get; set; } 
        public int UId { get; set; } 
    }
}
