using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PatientRecordService.Models
{
    public class LabReport
    {
        [Key]
        public int ReportId { get; set; }
        [ForeignKey("PatientId")]
        public int PatientId { get; set; }
        public string ReportType { get; set; } = string.Empty;
        public DateTime ReportDate { get; set; }
        public string Results { get; set; } = string.Empty;
    }
}
