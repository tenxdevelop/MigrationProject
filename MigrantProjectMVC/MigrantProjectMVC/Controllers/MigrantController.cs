using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.Controllers
{
    [ApiController]
    public class MigrantController : BaseController
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("getMigrant")]
        public IActionResult GetMigrant(string name, string surname, string patronymic)
        {
            var query = new GetMigrantQuery(name, surname, patronymic);
            var migrant = queryProcessor.Process(query);
            return Ok(migrant);
        }

        //[Authorize(Roles = "Migrant")]
        [HttpPost("ChangeData")]
        public IActionResult ChangeData(Guid migrantId, DateTime enteringDate, string country, bool resettelmentProgramMember,
            bool consistOfMigrationRegistration, bool highlyQualifled)
        {
            var command = new UpdateDataMigrantCommand(migrantId, enteringDate, country, resettelmentProgramMember, consistOfMigrationRegistration, highlyQualifled);
            var result = commandProcessor.Process(command);
            return Ok(result);
        }


    }
}
