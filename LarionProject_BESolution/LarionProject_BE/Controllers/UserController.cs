using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Services.Interfaces;

namespace LarionProject_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Create user 
        [HttpPost("create-user")]
        public async Task<IActionResult> createUser(UserDTO userDTO)
        {
            try
            {
                var user = await _userService.createUser(userDTO);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Login Action 
        [HttpPost("login")]
        public async Task<IActionResult> loginUser(string username, string password)
        {
            try
            {
                var user = await _userService.loginUser(username, password);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
