using Microsoft.EntityFrameworkCore;
using DoctorService.Models;

namespace DoctorService.Contexts
{
    public class DoctorContext : DbContext
    {
        public DoctorContext(DbContextOptions<DoctorContext> options):base(options) 
        {
            
        }
        public DbSet<Schedule> Schedules { get; set; }  
    }
}
