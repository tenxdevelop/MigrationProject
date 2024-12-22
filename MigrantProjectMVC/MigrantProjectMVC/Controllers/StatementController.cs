using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Queries;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MigrantProjectMVC.Controllers
{
    public class StatementController : BaseController
    {

        public IActionResult Index()
        {
            return View();
        }
 
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
        [HttpGet]
        public async Task<IActionResult> GetNewStatement()
        {
            var query = new GetNewStatementQuery();
            var result = await queryProcessor.Process(query);
            return View("StatementCheck");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> SetStatementStatus(Guid id, StatusType status)
        {
            var command = new SetStatementStatusCommand(id, status);
            var result = await commandProcessor.Process(command);
            return Ok(result);
        }

        [Authorize(Roles = "PlaceOwner")]
        [HttpPost]
        public async Task<IActionResult> CreateStatemenet(string name, string surname, string patronymic, string previousAddress, string accountingAddress)
        {
            var token = HttpContext.Request.Cookies["Auth"];
            var jwtSecurityHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtSecurityHandler.ReadJwtToken(token);
            var id = new Guid(jwtToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);

            var query = new GetUserByIdQuery(id);
            var placeOwner = queryProcessor.Process(query).Result;

            var command = new CreateStatementCommand(name, surname, patronymic, previousAddress, accountingAddress, placeOwner);
            var result = await commandProcessor.Process(command);
            if(result)
                return View("StatementRequestSuccess");
            return View("../Home/Index");
        }
    }
}
