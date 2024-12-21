using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.Controllers
{
    public class UserController : BaseController
    {

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //completed
        [HttpPost]
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

            return View("../Home/Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Prof()
        {
            var query = new GetUserQuery("admin", "admin", "admin");

            var model = queryProcessor.Process(query).Result;

            return View(model);
        }


        //completed
        [HttpPost()]
        public IActionResult Register(string name, string surname, string patronymic, string email, string phone, string password)
        {
            var command = new RegisterUserCommand()
            {
                Email = email,
                Phone = phone,
                Password = password
            };
            var text = commandProcessor.Process(command);

            return View("Login");
           
        }

        //completed
        [Authorize(Roles = "Admin")]
        [HttpPost("CreateUserStatement")]
        public IActionResult CreateUserStatement(string name, string surname, string patronymic, string email, string password)
        {
            var command = new CreateUserStatementCommand(name, surname, patronymic, email, password);
            var result = commandProcessor.Process(command);
            return Ok(result);
        }

        //completed
        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var query = new GetUserListQuery();
            var users = queryProcessor.Process(query);
            return Ok(users);
        }

        //completed
        [Authorize(Roles = "Admin")]
        [HttpPost("DeleteUser")]
        public IActionResult DeleteUser(Guid id)
        {
            var command = new DeleteUserCommand(id);
            var result = commandProcessor.Process(command);
            if (!result.Result)
            {
                return Json(new { status = "fail", message = "user not found" });
            }
            return Json(new { status = "success", message = "customer created" });
        }

        //completed
        [Authorize(Roles = "Admin")]
        [HttpPost("SetRole")]
        public IActionResult SetRole(Guid id, RoleModel role)
        {
            var command = new SetRoleCommand(id, role);
            var result = commandProcessor.Process(command);
            return Ok(result);
        }

        //completed
        [Authorize(Roles = "Admin")]
        [HttpGet("GetUser")]
        public IActionResult GetUser(string name, string surname, string patronymic)
        {
            var query = new GetUserQuery(name, surname, patronymic);
            var result = queryProcessor.Process(query);
            return Ok(result);

        }

        //test pages
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
