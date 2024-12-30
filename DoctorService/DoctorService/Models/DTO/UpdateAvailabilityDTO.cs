namespace DoctorService.Models.DTO
{
    public class UpdateAvailabilityDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool isAvailable { get; set; }   
    }
}
