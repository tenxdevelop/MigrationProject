using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Queries;
using MigrantProjectMVC.QueryHandlers;

namespace MigrantProjectMVC.Controllers
{
    [ApiController]
    public class RoleController : BaseController
    {
        //completed
        [Authorize(Roles = "Admin")]
        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var query = new GetRolesListQuery();
            var roles = queryProcessor.Process(query);
            return Ok(roles);
        }
    }
}
