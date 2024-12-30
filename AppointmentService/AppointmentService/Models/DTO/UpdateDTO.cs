namespace AppointmentService.Models.DTO
{
    public class UpdateDTO
    {
        public int DoctorId { get; set; }
       
        public DateTime AppointmentDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
