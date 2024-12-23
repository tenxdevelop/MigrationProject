using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Queries;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MigrantProjectMVC.Controllers
{
    public class DocumentController : BaseController
    {

        public async Task<IActionResult> Document()
        {
            ViewBag.DocumentTypes = new List<DocumentType>() { DocumentType.VISA, DocumentType.MIGRATIONCARD, DocumentType.PASSPORTMIGRANT, DocumentType.PASSPORTPLACEOWNER };
            var query = new GetAllDocsTypesQuery();
            var docsTypes = await queryProcessor.Process(query);
            ViewBag.DocsTypes = docsTypes;
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateDocument(string name, string content)
        {
            var token = HttpContext.Request.Cookies["Auth"];
            var jwtSecurityHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtSecurityHandler.ReadJwtToken(token);
            var id = new Guid(jwtToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
            var creationDate = DateTime.Now;
            var command = new CreateDocumentCommand(id, name, content, creationDate); // Сюда ещё нужно передавать Id user-a, что бы за ним закреплять документ
            var result = await commandProcessor.Process(command);
            ViewBag.DocumentTypes = new List<DocumentType>() { DocumentType.VISA, DocumentType.MIGRATIONCARD, DocumentType.PASSPORTMIGRANT, DocumentType.PASSPORTPLACEOWNER };
            var query = new GetAllDocsTypesQuery();
            var docsTypes = await queryProcessor.Process(query);
            ViewBag.DocsTypes = docsTypes;
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
