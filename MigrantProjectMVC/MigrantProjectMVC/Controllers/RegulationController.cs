using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.Controllers
{
    [ApiController]
    public class RegulationController : BaseController
    {
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
