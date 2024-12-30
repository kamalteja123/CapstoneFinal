using System.Security.Cryptography;
using System.Text;
using UserManagement.Interfaces;
using UserManagement.Models.DTO;
using UserManagement.Models;

namespace UserManagement.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<int, User> _repository;
        private readonly ILogger<UserService> _logger;
        private readonly ITokenService _tokenService;

        public UserService(IRepository<int, User> repository,
                            ILogger<UserService> logger,
                            ITokenService tokenService)
        {
            _repository = repository;
            _logger = logger;
            _tokenService = tokenService;
        }

        public async Task<AddRoleDTO> ChangeRole(AddRoleDTO addRoleDTO)
        {
            var userrole = await _repository.Get(addRoleDTO.UId);
            if (addRoleDTO == null)
            {
                throw new Exception("could not found it");
            }
            userrole.Role = addRoleDTO.Role;
            await _repository.Update(addRoleDTO.UId, userrole);
            return addRoleDTO;
        }

        public async Task<ICollection<User>> GetUsers()
        {
            var users= await _repository.GetAll();
            return users;
        }

        public async Task<ResponseDTO> Login(LoginRequestDTO loginRequest)
        {
            var user = await _repository.GetByString(loginRequest.Email);
            if (user == null)
            {
                _logger.LogCritical("User login attempt failed, Invalid username");
                throw new Exception("User not found");
            }
            HMACSHA256 hmac = new HMACSHA256(user.Key);
            var password = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginRequest.Password));
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] != user.Password[i])
                {
                    _logger.LogWarning("User login attempt failed, Invalid password");
                    throw new Exception("Invalid password");
                }
            }
            var userResponse = new ResponseDTO
            {
                UId = user.UId,
                Email = user.Email,
                Role = user.Role,
                Status = user.Status,
            };
            userResponse.Token = await _tokenService.GenerateToken(userResponse);
            return userResponse;
        }

        public async Task<ResponseDTO> Register(UserRegisterRequestDTO userRequest)
        {
            HMACSHA256 hmac = new HMACSHA256();
            User user = new User();
            user.Email = userRequest.Email;
            user.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRequest.Password));
            user.Role = userRequest.Role;
            user.Status = "Active";
            user.Key = hmac.Key;
            var result = await _repository.Add(user);
            if (result == null)
            {
                _logger.LogWarning("User creation failed");
                throw new Exception("User not added");
            }
            var userResponse = new ResponseDTO
            {
                UId = user.UId,
                Email = user.Email,
                Role = user.Role,
                Status = user.Status,
            };
            userResponse.Token = await _tokenService.GenerateToken(userResponse);
            return userResponse;
        }
    }
}
