using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoctorService.Models
{
    public class Schedule
    {
        [Key] 
        public int ScheduleId { get; set; }
    
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }=string.Empty;
        public DateTime StartTime { get; set; } 
        public DateTime EndTime { get; set; } 
       
        public bool IsAvailable { get; set; }
    }
}
