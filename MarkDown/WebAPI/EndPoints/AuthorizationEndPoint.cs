using Microsoft.AspNetCore.Mvc;

namespace WebAPI.EndPoints
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationEndPoint : ControllerBase
    {
        [HttpPost("regiter")]
        public IActionResult Register() 
        {

        }

        [HttpPost("login")]
        public IActionResult Login() 
        {

        }
    }
}
