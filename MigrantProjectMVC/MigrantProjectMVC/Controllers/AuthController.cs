using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using System.Numerics;
using System.Xml.Linq;

namespace MigrantProjectMVC.Controllers
{
    [ApiController]
    public class AuthController : BaseController
    {
        IUserRepository _userRepository;
        ITokenProvider _tokenProvider;
        UserModel _user { get; set; }

        public AuthController( IUserRepository userRepository, ITokenProvider tokenProvider, ICommandProcessor commandProcessor)
        {
            _userRepository = userRepository;
            _tokenProvider = tokenProvider;
        }
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserModel login)
        {
            var command = new LoginUserCommand()
            {
                Email = login.Email,
                Password = login.Password,
                Phone = login.Phone,
            };
            var token = commandProcessor.Process(command).Result;
            if (token == null) 
            {
                return Json(new { status = "error", message = "error logining" });
            }
            Response.Cookies.Append("Auth", token);
            return Ok(token);
        }

        [HttpPost("register")]
        public IActionResult Register(int Id, string name, string surname, string patronymic, string email, string phone, string password, string Role)
        {
            var command = new RegisterUserCommand()
            {
                Id = Id,
                Name = name,
                Surname = surname,
                Patronymic = patronymic,
                Email = email,
                Phone = phone,
                Password = password,
                Role = Role
            };
            var text = commandProcessor.Process(command);
            return Ok(text);
           
        }
        [Authorize]
        [HttpGet("securedPage")]
        public IActionResult SecuredPage()
        {
            return Ok();
        }

        [HttpGet("Page protected with role")]
        [Authorize(Roles = "Admin")]
        public IActionResult RoledPage()
        {
            return Ok("Enter on page with role protection");
        }
        [HttpPost ("logout")]
        [Authorize]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("Auth");
            return Ok();
        }

    }
}
