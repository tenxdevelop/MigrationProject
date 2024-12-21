using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Commands;

namespace MigrantProjectMVC.Controllers
{
    [ApiController]
    public class ApiUserController : BaseController
    {
        [HttpGet("login")]
        public IActionResult Login(string? email, string? phone, string password)
        {
            var command = new LoginUserCommand()
            {
                Email = email,
                Phone = phone,
                Password = password,
            };

            var token = commandProcessor.Process(command).Result;
            if (token == null)
            {
                return Json(new { status = "error", message = "error logining" });
            }
            Response.Cookies.Append("Auth", token);

            return Ok(token);
        }


    }
}
