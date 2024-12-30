using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Interfaces;
using UserManagement.Models.DTO;
using UserManagement.Filters;
using UserManagement.Models;
namespace UserManagement.Controllers
{
    [Route("api/user")]
    [ApiController]
    [CustomExceptionFilter]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        { 
            _userService = userService; 
        }
        [HttpPost("registerAdmin")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseDTO>> RegisterAdmin([FromBody] UserRegisterRequestDTO userRequest) 
        { 
            
                var response = await _userService.Register(userRequest);
                return Ok(response); 
            
        }
        [HttpPost("register")]
        public async Task<ActionResult<ResponseDTO>> Register(UserRegisterRequestDTO registerRequest)
        {
            var user = await _userService.Register(registerRequest);
            return Ok(user);
        }
        [HttpPost("login")]
        public async Task<ActionResult<ResponseDTO>> Login(LoginRequestDTO loginRequest)
        {
            var user = await _userService.Login(loginRequest);
            
            return Ok(user);
        }
       
        [HttpPut]
        [Authorize(Roles = "Admin")] 
        public async Task<ActionResult> ChangeRoles(AddRoleDTO addRoleDTO)
        {
            var user=await _userService.ChangeRole(addRoleDTO);
            return Ok();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ICollection<User>>> GetAllUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }
    }
}
