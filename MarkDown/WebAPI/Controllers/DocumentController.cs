using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly DocumentService _documentService;
        private readonly UsersService _usersService;

        public DocumentController(
            DocumentService documentService, 
            UsersService usersService)
        {
            _documentService = documentService;
            _usersService = usersService;
        }

        [HttpPost("save")]
        public async Task<IActionResult> SaveDocumentAsync([FromForm] TextContract htmlText) 
        {
            return Ok();
        }
    }
}
