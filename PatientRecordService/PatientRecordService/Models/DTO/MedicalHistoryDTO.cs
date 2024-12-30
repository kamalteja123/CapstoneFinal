namespace PatientRecordService.Models.DTO
{
    public class MedicalHistoryDTO
    {
        public int PatientId { get; set; }
        public string Condition { get; set; } = string.Empty;
        public DateTime DiagnosisDate { get; set; }
        public string Treatment { get; set; } = string.Empty;
    }
}
