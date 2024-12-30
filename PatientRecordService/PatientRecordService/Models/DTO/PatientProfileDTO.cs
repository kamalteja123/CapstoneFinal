namespace PatientRecordService.Models.DTO
{
    public class PatientProfileDTO
    {
        public int PatientId {  get; set; } 
        public string PatientName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

    }
}
