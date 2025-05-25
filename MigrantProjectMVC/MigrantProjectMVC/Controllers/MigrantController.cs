using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Application.Features.Queries.Queries;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.ViewModel;

namespace MigrantProjectMVC.Controllers
{

    public class MigrantController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> RegisterMigrantData()
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
            return View(URL_REGISTER_MIGRANT_DATA);
        }
        
        [HttpPost]
        public async Task<IActionResult> RegisterMigrant(string name, string surname, string patronymic, DateTime enteringDate, string countryName, string? documentNames)
        {
            var documentNamesParsed = new List<string>();
            var jwtToken = GetJwtToken();
            var userId = new Guid(jwtToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
            
            if (documentNames is not null)
            {
                documentNamesParsed = documentNames.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            
            var command = new RegisterMigrantCommand(userId, name, surname, patronymic, enteringDate, countryName, documentNamesParsed);
            
            var result = await commandProcessor.Process(command);

            var sharedViewModel = SharedViewModel.Create(result);
            return View(URL_HOME, sharedViewModel);
        }
    }
}