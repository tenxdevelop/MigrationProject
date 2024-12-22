using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Queries;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MigrantProjectMVC.Controllers
{
    public class MigrantController : BaseController
    {
        [HttpGet]
        public IActionResult DataControl()
        {
            var token = HttpContext.Request.Cookies["Auth"];
            var jwtSecurityHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtSecurityHandler.ReadJwtToken(token);
            var id = new Guid(jwtToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);

            var query = new GetMigrantByIdQuery(id);

            var migrantModel = queryProcessor.Process(query).Result;

            return View("DataControl", migrantModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getMigrant")]
        public IActionResult GetMigrant(string name, string surname, string patronymic)
        {
            var query = new GetMigrantQuery(name, surname, patronymic);
            var migrant = queryProcessor.Process(query);
            return Ok(migrant);
        }

        [Authorize(Roles = "Migrant")]
        [HttpPost]
        public IActionResult ChangeData(Guid migrantId, DateTime enteringDate, string country, bool ResettelmentProgramMember,
            bool ConsistOfMigrationRegistration, bool HighlyQualified)
        {
            var command = new UpdateDataMigrantCommand(migrantId, enteringDate, country, ResettelmentProgramMember, ConsistOfMigrationRegistration, HighlyQualified);
            var result = commandProcessor.Process(command);

            return DataControl();
        }
    }
}
