using ManagementTask.DTO.UsersDTO;
using ManagementTask.Message;
using ManagementTask.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementTask.Controllers
{
    [Route("Users/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _context;
        public UserController(UserService context ) 
        {
            _context = context;
        }
        [HttpPost("AddUsers")]
        public IActionResult AddUsers([FromBody]AddUserDto AddUser)
        {
            return Ok(_context.AddUser(AddUser));
        }
        [HttpDelete("DeleteUser/{UserId}")]
        public IActionResult DeleteUser(string UserId)
        {
            return Ok(_context.DeleteUser(UserId));
        }
        [HttpPut("UpdateUser/{UserId}")]
        public IActionResult UpdateUser([FromBody]UpdateUserDto NewUserData, string UserId)
        {
            return Ok(_context.UpdateUser(NewUserData,UserId));
        }
        [HttpGet("GetAllUser")]
        public IActionResult GetAllUser()
        {
            var result = _context.GetAllUser();
            if ( result == null || !result.Any())
            {
                return BadRequest(result);
            }
            return Ok( result );    
        }
        [HttpGet("GetUserById/{UserId}")]
        public IActionResult GetUserById(string UserId)
        {
            var result = _context.GetUserById(UserId);
            if (result == null || !result.Any())
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
