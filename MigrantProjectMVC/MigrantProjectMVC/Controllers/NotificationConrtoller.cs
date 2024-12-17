﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.Controllers
{
    [ApiController]
    public class NotificationConrtoller : BaseController
    {
        [Authorize]
        [HttpGet("GetNotification")]
        public async Task<IActionResult> GetNotification(Guid id)
        {
            var query = new GetNotificationQuery(id);
            var result = await queryProcessor.Process(query);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetAllTypes")]
        public async Task<IActionResult> GetAllTypes()
        {
            var query = new GetAllNotificationTypesQuery();
            var types = Enum.GetValues(typeof(NotificationType)).Cast<NotificationType>().Select(x => x.ToString()).ToList();
            return Ok(types);
        }


    }
}
