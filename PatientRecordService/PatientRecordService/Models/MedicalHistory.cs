using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientRecordService.Models
{
    public class MedicalHistory
    {
        [Key] 
        public int HistoryId { get; set; }
        [ForeignKey("PatientId")]
        public int PatientId { get; set; }
        public string Condition { get; set; } = string.Empty;
        public DateTime DiagnosisDate { get; set; }
        public string Treatment { get; set; } = string.Empty;
              
    }
}
