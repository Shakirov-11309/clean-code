using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PagesController : Controller
    { 

        [HttpGet("/index")]
        public IActionResult Index() => View("index");

        [HttpGet("/login")]
        public IActionResult Login() => View("login");

        [HttpGet("/reg")]
        public IActionResult SubmitData() => View("reg");
    }
}
