using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.Controllers
{
    public class BaseController : Controller
    {
        public const string COOKIES_KEY_AUTH_TOKEN = "Auth";
        
        public const string URL_HOME = "../Home/Index";
        public const string URL_LOGIN = "../User/Login";
        public const string URL_REGISTER = "../User/Register";
        
        private ICommandProcessor _commandProcessor;
        private IQueryProcessor _queryProcessor;
        protected ICommandProcessor commandProcessor => _commandProcessor ??= HttpContext.RequestServices.GetRequiredService<ICommandProcessor>();
        protected IQueryProcessor queryProcessor => _queryProcessor ??= HttpContext.RequestServices.GetRequiredService<IQueryProcessor>();

        
    }
}
