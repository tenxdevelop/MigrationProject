using MigrantProjectMVC.Application.Features.Queries.Queries;
using MigrantProjectMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MigrantProjectMVC.Controllers
{
    public class RefferalController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> ShowRefferalForm()
        {
            var jwtToken = GetJwtToken();
            var userId = new Guid(jwtToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);

            var isHaveMigrantDataQuery = new IsHaveMigrantDataByUserQuery(userId);
            var getAllTargetQuery = new GetAllTargetsQuery();
            
            var targets = await queryProcessor.Process(getAllTargetQuery);
            
            ViewBag.Targets = targets.Select(target => target.Name).ToList();
            var isHaveMigrantData = await queryProcessor.Process(isHaveMigrantDataQuery);
            var sharedViewModel  = SharedViewModel.Create(isHaveMigrantData);
            
            return View(URL_SHOW_REFFERAL_FORM, sharedViewModel);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetRefferal(string targetName, string name, string surname, string patronymic)
        {
            var jwtToken = GetJwtToken();
            var userId = new Guid(jwtToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);

            var isHaveMigrantDataQuery = new IsHaveMigrantDataByUserQuery(userId);
            
            var isHaveMigrantData = await queryProcessor.Process(isHaveMigrantDataQuery);
            
            var query = new GetRefferalQuery(targetName, name, surname, patronymic);
            
            var refferalViewModel = await queryProcessor.Process(query);
            refferalViewModel.IsHaveMigrantData = isHaveMigrantData;
            
            return View(URL_SHOW_REFFERAL, refferalViewModel);
        }
    }
}