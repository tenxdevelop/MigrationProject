using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public IActionResult Logout()
        {
            Response.Cookies.Delete(COOKIES_KEY_AUTH_TOKEN);
            return View(URL_HOME);
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
            return View(URL_HOME);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(URL_REGISTER);
        }

        [HttpPost]
        public async Task<IActionResult> Register(string email, string password)
        {
            var command = new RegisterUserCommand(email, password);
            
            var isRegister = await commandProcessor.Process(command);

            if (isRegister)
                return View(URL_LOGIN);
            
            return View(URL_REGISTER);
           
        }
        
    }
}
