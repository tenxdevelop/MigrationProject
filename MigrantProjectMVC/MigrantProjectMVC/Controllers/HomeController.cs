using Microsoft.AspNetCore.Mvc;

namespace MigrantProjectMVC.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
