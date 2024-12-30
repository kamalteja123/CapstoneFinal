using Microsoft.EntityFrameworkCore;
using PatientRecordService.Models;

namespace PatientRecordService.Contexts
{
    public class PatientRecordContext : DbContext
    {
        public PatientRecordContext(DbContextOptions<PatientRecordContext> options):base(options) 
        {
            
        }
   
        public DbSet<LabReport> LabReports { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
    }
}
