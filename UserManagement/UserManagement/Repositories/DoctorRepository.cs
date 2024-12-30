using Microsoft.EntityFrameworkCore;
using UserManagement.Contexts;
using UserManagement.Models;

namespace UserManagement.Repositories
{
    public class DoctorRepository : Repository<int, Doctor>
    {
        public DoctorRepository(UserAuthContext context)
        {
                _context = context;     
        }
        public async override Task<Doctor> Get(int key)
        {
            var doctor = _context.Doctors.Find(key);
            if (doctor == null)
            {
                throw new Exception("Entity not found");
            }
            return doctor;
        }

        public async override Task<ICollection<Doctor>> GetAll()
        {
            if (_context.Doctors.Count() == 0)
            {
                throw new Exception("No entities found");
            }
            return await _context.Doctors.ToListAsync();
        }
       
    }
}
