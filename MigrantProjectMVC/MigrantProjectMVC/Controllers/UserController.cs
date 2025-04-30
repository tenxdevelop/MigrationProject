using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Queries;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MigrantProjectMVC.Controllers
{
    public class UserController : BaseController
    {

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult ManipulationUser()
        {
            var query = new GetUserListQuery();
            var users = queryProcessor.Process(query).Result;
            ViewBag.UserModels = users;

            var queryRoles = new GetRolesListQuery();
            var roles = queryProcessor.Process(queryRoles).Result;
            ViewBag.Roles = roles;
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Authorize]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("Auth");
            return View("../Home/Index");
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
            if (string.IsNullOrEmpty(password))
                return View("Login");

            var token = commandProcessor.Process(command).Result;
            if (token == null) 
            {
                return View("Login");
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
            var token = HttpContext.Request.Cookies["Auth"];
            var jwtSecurityHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtSecurityHandler.ReadJwtToken(token);
            var id = new Guid(jwtToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
            ViewBag.Countries = new List<string>()
            {
                "Украина", "Белорусь"
            }; //временная задычка, замени потом на список из репозитория стран
            var query = new GetUserByIdQuery(id);
            var userModel = queryProcessor.Process(query).Result;

            return View(userModel);
        }


        //completed
        [HttpPost()]
        public IActionResult Register(string name, string surname, string patronymic, string email, string phone, string password, bool isMigrant = false)
        {
            var command = new RegisterUserCommand()
            {
                Name = name,
                Surname = surname,
                Patronymic = patronymic,
                Email = email,
                Phone = phone,
                Password = password,
                IsMigrant = isMigrant
            };
            var text = commandProcessor.Process(command);

            return View("Login");
           
        }

        [HttpPost]
        public IActionResult saveUserData(string firstName, string lastName, string patronymic, string email,
            string phone, string country, string documentNames) // Получаем как строку с разделителями
        {
            if (documentNames != null) {
                var documentsList = documentNames.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            } //проверка на тот случай, если у мигранта нет документов

            //все данные отправляются, осталось заполнить

            return View("../User/Prof");
        }

        //completed
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateUserStatement(string name, string surname, string patronymic, string email, string password)
        {
            var command = new CreateUserStatementCommand(name, surname, patronymic, email, password);
            var result = commandProcessor.Process(command);
            return View("../Home/Index");
        }

        //completed
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllUsers()
        {
            var query = new GetUserListQuery();
            var users = queryProcessor.Process(query);
            return Ok(users);
        }

        //completed
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteUser(Guid id)
        {
            var command = new DeleteUserCommand(id);
            var result = commandProcessor.Process(command);
            if (!result.Result)
            {
                return Json(new { status = "fail", message = "user not found" });
            }
            return View("../Home/Index");
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeleteSelf()
        {
            var token = HttpContext.Request.Cookies["Auth"];
            var jwtSecurityHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtSecurityHandler.ReadJwtToken(token);
            var id = new Guid(jwtToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
            var command = new DeleteUserCommand(id);
            var result = commandProcessor.Process(command);
            if (!result.Result)
            {
                return Json(new { status = "fail", message = "user not found" });
            }

            Response.Cookies.Delete("Auth");
            return View("../Home/Index");
        }

        //completed
        [Authorize(Roles = "Admin")]
        public IActionResult SetRole(Guid id, string roleName)
        {
            var command = new SetRoleCommand(id, new RoleModel() { Name = roleName });
            var result = commandProcessor.Process(command).Result;

            
            return View("../Home/Index");
        }

        //completed
        [Authorize(Roles = "Admin")]
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
    }
}
