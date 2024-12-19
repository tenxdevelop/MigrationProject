﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.Controllers
{
    public class NotificationConrtoller : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {

            return View("Index");
        }

        [HttpGet]
        public IActionResult DetailsNotification()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetNotification(Guid id)
        {
            var query = new GetNotificationQuery(id);
            var result = await queryProcessor.Process(query);
            return Ok(result);
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
    }
}
