
using UserManagement.Models.DTO;

namespace UserManagement.Interfaces
{
    public interface ITokenService
    {
        public Task<string> GenerateToken(ResponseDTO user);
    }
}
