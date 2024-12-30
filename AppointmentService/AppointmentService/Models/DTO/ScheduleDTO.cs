namespace AppointmentService.Models.DTO
{
    public class ScheduleDTO
    {
        public int ScheduleId { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }=string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAvailable { get; set; }
    }
}
