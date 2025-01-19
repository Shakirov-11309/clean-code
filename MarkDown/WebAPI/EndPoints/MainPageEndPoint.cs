using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainPageController : ControllerBase
    {
        private readonly ILogger<MainPageController> _logger;

        public MainPageController(ILogger<MainPageController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetMainpage")]
        public IActionResult Get()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "public", "index.html"); // Путь к вашему HTML файлу

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found");
            }
            var htmlString = System.IO.File.ReadAllText(filePath);
            return Content(htmlString, "text/html");
        }
    }
}
