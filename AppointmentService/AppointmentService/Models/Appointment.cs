using System.ComponentModel.DataAnnotations;

namespace AppointmentService.Models
{
    public class Appointment
    {
        [Key] 
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; } = "Booked";
    }
}
