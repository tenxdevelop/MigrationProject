using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Application.Features.Queries.Queries;
using MigrantProjectMVC.Commands;

namespace MigrantProjectMVC.Controllers
{
    public class TargetController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetTargets()
        {
            var query = new GetAllTargetsQuery();
            var result = await queryProcessor.Process(query);
            
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetRegulations(string targetName)
        {
            var query = new GetRegulationsQuery(targetName);
            
            var result = await queryProcessor.Process(query);
            return Ok(result);
        }
        
        [HttpPut]
        public async Task<IActionResult> ChangeCondition(string targetName, string newInsctuction)
        {
            var command = new ChangeConditionCommand(targetName, newInsctuction);
            
            var result = await commandProcessor.Process(command);
            
            return Ok(result);
        }
        
        [HttpPut]
        public async Task<IActionResult> ChangeRegulation(string targetName, string regulationName, List<string> countriesName, List<string> useDocuments, int term)
        {
            var command = new ChangeRegulationCommand(targetName, regulationName, countriesName, useDocuments, term);
            
            var result = await commandProcessor.Process(command);
            
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTarget(string targetName)
        {
            var command = new DeleteTargetCommand(targetName);
            
            var result = await commandProcessor.Process(command);
            
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRegulation(string targetName, string regulationName)
        {
            var command = new DeleteRegulationCommand(targetName, regulationName);

            var result = await commandProcessor.Process(command);
            
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTarget(string targetName)
        {
            var command = new RegisterTargetCommand(targetName);

            var result = await commandProcessor.Process(command);
            
            return Ok(result);
        }
    }
}