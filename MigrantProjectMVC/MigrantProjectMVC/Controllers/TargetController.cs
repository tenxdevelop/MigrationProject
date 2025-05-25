using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Application.Features.Queries.Queries;
using MigrantProjectMVC.Commands;

namespace MigrantProjectMVC.Controllers
{
    public class TargetController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> InstructionChange()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ChangeRegulation()
        {
            var query = new GetAllCountriesQuery();
            var countryModels = await queryProcessor.Process(query);
            var countries = countryModels.Select(country => country.Name).ToList();

            if (countries.Count.Equals(0))
            {
                HttpContext.Response.StatusCode = 404;
                return Content("don't have country");
            }

            ViewBag.Countries = countries;

            

            return View();
        }

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
        
        [HttpPost]
        public async Task<IActionResult> ChangeCondition(string targetName, string newInsctuction)
        {
            var command = new ChangeConditionCommand(targetName, newInsctuction);
            
            var result = await commandProcessor.Process(command);
            
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> ChangeRegulation(string targetName, string regulationName, List<string> countriesName, List<string> useDocuments, int term)
        {
            var countries = countriesName[0].Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            var documents = useDocuments[0].Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            var command = new ChangeRegulationCommand(targetName, regulationName, countries, documents, term);
            
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