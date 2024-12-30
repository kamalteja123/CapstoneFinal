namespace PatientRecordService.Models.DTO
{
    public class LabReportDTO
    {
        public int PatientId { get; set; }
        public string ReportType { get; set; } = string.Empty;
        public DateTime ReportDate { get; set; }
        public string Results { get; set; } = string.Empty;
    }
}
