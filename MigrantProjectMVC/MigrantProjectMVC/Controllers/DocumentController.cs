using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.Controllers
{
    public class DocumentController : BaseController
    {

        public IActionResult Document()
        {
            ViewBag.DocumentTypes = new List<DocumentType>() { DocumentType.VISA, DocumentType.MIGRATIONCARD, DocumentType.PASSPORTMIGRANT, DocumentType.PASSPORTPLACEOWNER };
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateDocument(string name, string content)
        {
            var creationDate = DateTime.Now;
            var command = new CreateDocumentCommand(name, content, creationDate);
            var result = await commandProcessor.Process(command);

            ViewBag.DocumentTypes = new List<DocumentType>() { DocumentType.VISA, DocumentType.MIGRATIONCARD, DocumentType.PASSPORTMIGRANT, DocumentType.PASSPORTPLACEOWNER };
            return View("Document");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllDocumentsByStatementId(Guid id)
        {
            var query = new GetDocumentListQuery(id);
            var result = await queryProcessor.Process(query);
            return Ok(result);
        }
    }
}
