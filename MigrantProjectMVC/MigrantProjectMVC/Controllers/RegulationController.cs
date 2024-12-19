using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Queries;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MigrantProjectMVC.Controllers
{
    public class RegulationController : BaseController
    {

        public async Task<IActionResult> Reglament()
        {
            var token = HttpContext.Request.Cookies["Auth"];
            var jwtSecurityHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtSecurityHandler.ReadJwtToken(token);
            var id = new Guid(jwtToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);

            var query = new GetMigrantByIdQuery(id);

            var migrantModel = queryProcessor.Process(query).Result;

            ViewBag.Name = migrantModel.Name;
            ViewBag.Email = migrantModel.Email;
            var query2 = new GetRegulationQuery(migrantModel.Email);

            var data = await queryProcessor.Process(query2);
            int term;
            if (data is null)
                term = 7;
            else
                term = data.Term;
            ViewBag.Date = migrantModel.EnteringDate.AddDays(term);
            ViewBag.CountDay = term;

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetRegulation")]
        public async Task<IActionResult> GetRegulation(string email)
        {
            var query = new GetRegulationQuery(email);
            var data = await queryProcessor.Process(query);
            return Ok(data);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("GetRegulationsList")]
        public async Task<IActionResult> GetRegulationList()
        {
            var query = new GetRegulationListQuery();
            var data = await queryProcessor.Process(query);
            return Ok(data);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("UpdateRegulation")]
        public async Task<IActionResult> UpdateRegulation(RegulationModel regulation)
        {
            var command = new UpdateRegulationTermCommand(regulation);
            var data = await commandProcessor.Process(command);
            return Ok(data);
        }


    }
}
