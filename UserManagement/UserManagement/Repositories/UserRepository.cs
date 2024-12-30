using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UserManagement.Contexts;
using UserManagement.Models;

namespace UserManagement.Repositories
{
    public class UserRepository : Repository<int, User>
    {
        public UserRepository(UserAuthContext context)
        {
            _context = context;
        }

        public async override Task<User> Get(int key)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UId == key);
            if (user == null)
            {
                throw new Exception("Entity not found");
            }
            return user;
        }

        public async override Task<ICollection<User>> GetAll()
        {
            if (_context.Users.Count() == 0)
            {
                throw new Exception("No entities found");
            }
            return await _context.Users.ToListAsync();

        }
       
    }
}
