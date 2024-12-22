using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Queries;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MigrantProjectMVC.Controllers
{
    public class NotificationController : BaseController
    {

        [Authorize(Roles="PlaceOwner")]
        [HttpGet]
        public async Task<IActionResult> GetAllNotification()
        {
            var token = HttpContext.Request.Cookies["Auth"];
            var jwtSecurityHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtSecurityHandler.ReadJwtToken(token);
            var id = new Guid(jwtToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);

            var query = new GetAllNotificationQuery(id);
            var result = queryProcessor.Process(query).Result.ToList();
            return View("Index", result);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetNotification(Guid id)
        {
            var query = new GetNotificationQuery(id);
            var result = await queryProcessor.Process(query);
            return View("DetailsNotification", result);
        }


        public List<NotificationType> GetAllTypes()
        {
            var query = new GetAllNotificationTypesQuery();
            var types = Enum.GetValues(typeof(NotificationType)).Cast<NotificationType>().ToList();
            return types;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateNotification(Guid statementId, string name, string surname, string patronymic, NotificationType type)
        {
            var command = new CreateNotificationCommand(statementId, name, surname, patronymic);
            var result = await commandProcessor.Process(command);
            if (result)
            {
                var setTypeCommand = new SetNotificationTypeCommand(statementId, type);
                result = await commandProcessor.Process(setTypeCommand);
                if (result)
                    return View("../Home/Index");
                
            }
            return Ok(result);
        }


        [Authorize(Roles ="MVD")]
        [HttpGet]
        public IActionResult CreateNotification()
        {
            var query = new GetAllStatementsQuery();
            var result = queryProcessor.Process(query).Result;
            var model = result.Where(statement => statement.Status.Equals(StatusType.APPROVED) || statement.Status.Equals(StatusType.DENIED)).ToList();
            var types = GetAllTypes();
            ViewBag.NotificationTypes = types;

            return View(model);
        }
    }
}
