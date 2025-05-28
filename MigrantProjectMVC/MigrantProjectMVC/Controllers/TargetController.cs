using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Application.Features.Queries.Queries;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.ViewModel;

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
            
            return await ShowHome(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> ChangeRegulation(string targetName, string regulationName, List<string> countriesName, List<string> useDocuments, int term)
        {
            var countries = new List<string>();
            
            if (countriesName[0] is not null)
            {
                countries = countriesName[0].Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            var documents = new List<string>();
            
            if (useDocuments[0] is not null)
            {
                documents = useDocuments[0].Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            var command = new ChangeRegulationCommand(targetName, regulationName, countries, documents, term);
            
            var result = await commandProcessor.Process(command);
            
            return await ShowHome(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTarget(string targetName)
        {
            var command = new DeleteTargetCommand(targetName);
            
            var result = await commandProcessor.Process(command);
            
            return await ShowHome(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRegulation(string targetName, string regulationName)
        {
            var command = new DeleteRegulationCommand(targetName, regulationName);

            var result = await commandProcessor.Process(command);
            
            return await ShowHome(result);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTarget(string targetName)
        {
            var command = new RegisterTargetCommand(targetName);

            var result = await commandProcessor.Process(command);
            
            return await ShowHome(result);
        }

        private async Task<IActionResult> ShowHome(bool result)
        {
            if (result)
            {
                SharedViewModel sharedViewModel;
            
                var jwtToken = GetJwtToken();
            
                if (jwtToken is null)
                {
                    sharedViewModel = SharedViewModel.Create(false);
                }
                else
                {
                    var userId = new Guid(jwtToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
                    Console.WriteLine(userId);
                    var query = new IsHaveMigrantDataByUserQuery(userId);
            
                    var isHaveMigrantData = await queryProcessor.Process(query);
                    sharedViewModel = SharedViewModel.Create(isHaveMigrantData);
                }
            
                return View(URL_HOME, sharedViewModel);
            }
            
            return Ok(result);
        }
    }
}