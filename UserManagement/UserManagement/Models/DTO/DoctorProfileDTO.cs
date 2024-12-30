namespace UserManagement.Models.DTO
{
    public class DoctorProfileDTO
    {
        public string DoctorName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string Qualifications { get; set; } = string.Empty;
        public int YearsOfExperience { get; set; }

        //public string Role { get; set; } = string.Empty;
    }
}
