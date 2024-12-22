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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllTypes()
        {
            var query = new GetAllNotificationTypesQuery();
            var types = Enum.GetValues(typeof(NotificationType)).Cast<NotificationType>().Select(x => x.ToString()).ToList();
            return Ok(types);
        }

        [Authorize]
        [HttpPost("CreateNotification")]
        public async Task<IActionResult> CreateNotification(Guid statementId, string name, string surname, string patronymic)
        {
            var command = new CreateNotificationCommand(statementId, name, surname, patronymic);
            var result = await commandProcessor.Process(command);
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SetNotificationType(Guid statementId, NotificationType type)
        {
            var command = new SetNotificationTypeCommand(statementId, type);
            var result = await commandProcessor.Process(command);
            return Ok(result);
        }
    }
}
