using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Diagnostics;
using WebAPI.Contracts;
using WebAPI.Services;

namespace WebAPI.EndPoints
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {

        private readonly UsersService _usersService;

        public UserController(UsersService usersService) 
        {
            _usersService = usersService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] UserContract user)
        {
            await _usersService.Register(user.Email, user.Password);
            return Ok();
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] UserContract user)
        {
            var token = await _usersService.Login(user.Email, user.Password);
            Response.Cookies.Append("cookie", token);
            return Ok(token);
        }

        [HttpGet("view/catalog")]
        public IActionResult GetDocuments([FromHeader] UserContract user) 
        {
            return Ok();
        }
    }
}
