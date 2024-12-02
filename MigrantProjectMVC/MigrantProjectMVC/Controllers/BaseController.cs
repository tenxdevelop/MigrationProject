using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.Controllers
{
    public class BaseController : Controller
    {

        private ICommandProcessor _commandProcessor;
        protected ICommandProcessor commandProcessor => _commandProcessor ??= HttpContext.RequestServices.GetRequiredService<ICommandProcessor>();
    }
}
