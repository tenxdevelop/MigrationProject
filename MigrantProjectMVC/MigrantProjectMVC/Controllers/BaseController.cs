using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.Controllers
{
    public class BaseController : Controller
    {

        private ICommandProcessor _commandProcessor;
        private IQueryProcessor _queryProcessor;
        protected ICommandProcessor commandProcessor => _commandProcessor ??= HttpContext.RequestServices.GetRequiredService<ICommandProcessor>();
        protected IQueryProcessor queryProcessor => _queryProcessor ??= HttpContext.RequestServices.GetRequiredService<IQueryProcessor>();

        
    }
}
