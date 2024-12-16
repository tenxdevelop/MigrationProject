using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.Controllers
{
    [ApiController]
    public class StatementController : BaseController
    {
        [Authorize(Roles ="Admin")]
        [HttpGet("GetStatementListByPlaceOWnerQuery")]
        public async Task<IActionResult> GetStatementListByPlaceOWner(Guid id)
        {
            var query = new GetStatementListByPlaceOWnerQuery(id);
            var result = await queryProcessor.Process(query);
            return Ok(result);
        }
    }
}
