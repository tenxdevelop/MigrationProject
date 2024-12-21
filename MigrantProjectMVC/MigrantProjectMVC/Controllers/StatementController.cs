using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.Controllers
{
    [ApiController]
    public class StatementController : BaseController
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("GetStatementListByPlaceOWnerQuery")]
        public async Task<IActionResult> GetStatementListByPlaceOWner(Guid id)
        {
            var query = new GetStatementListByPlaceOWnerQuery(id);
            var result = await queryProcessor.Process(query);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllStatements")]

        public async Task<IActionResult> GetAllStatements()
        {
            var query = new GetAllStatementsQuery();
            var result = await queryProcessor.Process(query);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetNewStatement")]
        public async Task<IActionResult> GetNewStatement()
        {
            var query = new GetNewStatementQuery();
            var result = await queryProcessor.Process(query);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("SetStatementStatus")]
        public async Task<IActionResult> SetStatementStatus(Guid id, StatusType status)
        {
            var command = new SetStatementStatusCommand(id, status);
            var result = await commandProcessor.Process(command);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("CreateStatementCommand")]
        public async Task<IActionResult> CreateStatemenet(string name, string surname, string patronymic, string previousAddress, string accountingAddress)
        {
            var command = new CreateStatementCommand(name, surname, patronymic, previousAddress, accountingAddress);
            var result = commandProcessor.Process(command);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("FillStatementWithMigrantData")]
        public async Task<IActionResult> FillStatementWithMigrantData(Guid statementId, string migrantName, string migrantSurname, string migrantPatronymic)
        {
            var command = new FillStatementWithMigrantDataCommand(statementId, migrantName, migrantSurname, migrantPatronymic);
            var result = await commandProcessor.Process(command);
            return Ok(result);
        }





    }
}
