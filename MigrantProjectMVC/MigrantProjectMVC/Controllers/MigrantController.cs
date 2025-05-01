using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.ViewModel;

namespace MigrantProjectMVC.Controllers
{

    public class MigrantController : BaseController
    {
        [HttpGet]
        public IActionResult RegisterMigrantData()
        {
            return View(URL_REGISTER_MIGRANT_DATA);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterMigrant(string name, string surname, string patronymic, DateTime enteringDate, string countryName, string documentNames)
        {
            var jwtToken = GetJwtToken();
            var userId = new Guid(jwtToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
            var documentNamesParsed = documentNames.Split(',').ToList();
            var command = new RegisterMigrantCommand(userId, name, surname, patronymic, enteringDate, countryName, documentNamesParsed);
            
            var result = await commandProcessor.Process(command);

            var sharedViewModel = SharedViewModel.Create(result);
            return View(URL_HOME, sharedViewModel);
        }
    }
}