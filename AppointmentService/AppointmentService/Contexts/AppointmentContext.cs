using Microsoft.EntityFrameworkCore;
using AppointmentService.Models;

namespace AppointmentService.Contexts
{
    public class AppointmentContext : DbContext
    {

        public AppointmentContext(DbContextOptions<AppointmentContext> options):base(options) 
        {
            
        }
        public DbSet<Appointment> Appointments { get; set; }  
    }
}
