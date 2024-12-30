using Microsoft.EntityFrameworkCore;
using PatientRecordService.Contexts;
using PatientRecordService.Models;

namespace PatientRecordService.Repositories
{
    public class MedicalHistoryRepoistory : Repository<int, MedicalHistory>
    {
        public MedicalHistoryRepoistory(PatientRecordContext context)
        {
            _context= context;
        }

        public async override Task<MedicalHistory> Get(int key)
        {
            var medicalRecord = _context.MedicalHistories.Find(key);
            if (medicalRecord == null)
            {
                throw new Exception("Entity not found");
            }
            return medicalRecord;
        }

        public async override Task<ICollection<MedicalHistory>> GetAll()
        {
            if (_context.MedicalHistories.Count() == 0)
            {
                throw new Exception("No entities found");
            }
            return await _context.MedicalHistories.ToListAsync();
        }
    }
}
