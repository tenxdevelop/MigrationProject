using MigrantProjectMVC.Application.Features.Queries.Queries;
using Microsoft.AspNetCore.Authorization;
using MigrantProjectMVC.ViewModel;
using MigrantProjectMVC.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MigrantProjectMVC.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View(URL_LOGIN);
        }

        //[Authorize]
        public IActionResult Logout()
        {
            Response.Cookies.Delete(COOKIES_KEY_AUTH_TOKEN);
       
            var sharedViewModel = SharedViewModel.Create(false);
            return View(URL_HOME, sharedViewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var command = new LoginUserCommand(email, password);
            
            if (string.IsNullOrEmpty(password))
                return View(URL_LOGIN);

            var token = await commandProcessor.Process(command);
            
            if (token is null)
                return View(URL_LOGIN);
            
            Response.Cookies.Append(COOKIES_KEY_AUTH_TOKEN, token);

            var userQuery = new GetUserByEmailQuery(email);
            var user = await queryProcessor.Process(userQuery);

            var isHaveMigrantDataQuery = new IsHaveMigrantDataByUserQuery(user.Id);
            var isHaveMigrantData = await queryProcessor.Process(isHaveMigrantDataQuery);
            var sharedViewModel = SharedViewModel.Create(isHaveMigrantData);
            
            return View(URL_HOME, sharedViewModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var registerViewModel = RegisterViewModel.Create(false, string.Empty);
            return View(URL_REGISTER, registerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(string email, string password)
        {
            var command = new RegisterUserCommand(email, password);
            
            var registerViewModel = await commandProcessor.Process(command);

            if (registerViewModel.IsRegisterSuccess)
                return View(URL_LOGIN);
            
            return View(URL_REGISTER, registerViewModel);
           
        }
        
    }
}
