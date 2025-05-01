using MigrantProjectMVC.Application.Features.Queries.Queries;
using MigrantProjectMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MigrantProjectMVC.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
        {
            
        }

        public async Task<IActionResult> Index()
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

                var query = new IsHaveMigrantDataByUserQuery(userId);
            
                var isHaveMigrantData = await queryProcessor.Process(query);
                sharedViewModel = SharedViewModel.Create(isHaveMigrantData);
            }
            
            return View(URL_HOME, sharedViewModel);
        }
    }
}
