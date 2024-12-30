
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UserManagement.Contexts;
using UserManagement.Models;

namespace UserManagement.Repositories
{
    public class PatientRepository : Repository<int, Patient>
    {
        
        public PatientRepository(UserAuthContext context)
        {
            _context = context;
        }

        public async override Task<Patient> Get(int key)
        {
            var patient = _context.Patients.Find(key);
            if (patient == null)
            {
                throw new Exception("Entity not found");
            }
            return patient;
        }

        public async override Task<ICollection<Patient>> GetAll()
        {
            if (_context.Patients.Count() == 0)
            {
                throw new Exception("No entities found");
            }
            return await _context.Patients.ToListAsync();
           
        }
       
    }
}
