using Microsoft.EntityFrameworkCore;
using PatientRecordService.Contexts;
using PatientRecordService.Models;

namespace PatientRecordService.Repositories
{
    public class LabReportRepository : Repository<int, LabReport>
    {
        public LabReportRepository(PatientRecordContext context )
        {
            _context = context;
        }
        public async  override Task<LabReport> Get(int key)
        {
            var labReport = _context.LabReports.Find(key);
            if (labReport == null)
            {
                throw new Exception("Entity not found");
            }
            return labReport;
        }

        public async override Task<ICollection<LabReport>> GetAll()
        {
            if (_context.LabReports.Count() == 0)
            {
                throw new Exception("No entities found");
            }
            return await _context.LabReports.ToListAsync();
        }
    }
}
