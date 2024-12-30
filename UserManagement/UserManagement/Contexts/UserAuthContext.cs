using Microsoft.EntityFrameworkCore;
using UserManagement.Models;

namespace UserManagement.Contexts
{
    public class UserAuthContext:DbContext
    {
        public UserAuthContext(DbContextOptions<UserAuthContext> options):base(options) 
        {
            
        }
        public DbSet<User> Users { get; set; }  
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }    
    }
}
