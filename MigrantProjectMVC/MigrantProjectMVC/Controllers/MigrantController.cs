using MigrantProjectMVC.Application.Features.Queries.Queries;
using MigrantProjectMVC.ViewModel;
using MigrantProjectMVC.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MigrantProjectMVC.Controllers
{
    public class MigrantController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> RegisterMigrantData()
        {
            var query = new GetAllCountriesQuery();
            
            var countires = await queryProcessor.Process(query);
            
            ViewBag.Countries = countires.Select(country => country.Name);
            return View(URL_REGISTER_MIGRANT_DATA);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterMigrant(string name, string surname, string patronymic, DateTime enteringDate, string countryName, string documentNames)
        {
            var jwtToken = GetJwtToken();
            var userId = new Guid(jwtToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
            var documentNamesParsed = documentNames.Split(',').Where(documentName => !string.IsNullOrEmpty(documentName)).ToList();
            var command = new RegisterMigrantCommand(userId, name, surname, patronymic, enteringDate, countryName, documentNamesParsed);
            
            var result = await commandProcessor.Process(command);

            var sharedViewModel = SharedViewModel.Create(result);
            return View(URL_HOME, sharedViewModel);
        }
    }
}