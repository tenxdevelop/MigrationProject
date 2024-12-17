using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.Controllers
{
    [ApiController]
    public class DocumentController : BaseController
    {
        [Authorize]
        [HttpPost("CreateDocument")]
        public async Task<IActionResult> CreateDocument(string name, string content, DateTime creationDate)
        {
            var command = new CreateDocumentCommand(name, content, creationDate);
            var result = await commandProcessor.Process(command);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetAllDocumentsByStatementId")]
        public async Task<IActionResult> GetAllDocumentsByStatementId(Guid id)
        {
            var query = new GetDocumentListQuery(id);
            var result = await queryProcessor.Process(query);
            return Ok(result);
        }
    }
}
