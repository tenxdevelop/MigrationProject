using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.Controllers
{
    [ApiController]
    public class RegulationController : BaseController
    {
        [HttpGet("GetRegulation")]
        public IActionResult GetRegulation(string email)
        {
            var query = new GetRegulationQuery(email);
            var data = queryProcessor.Process(query);
            return Ok(data);
        }

        [HttpGet("GetRegulationsList")]
        public IActionResult GetRegulationList()
        {
            var query = new GetRegulationListQuery();
            var data = queryProcessor.Process(query);
            return Ok(data);
        }


    }
}
