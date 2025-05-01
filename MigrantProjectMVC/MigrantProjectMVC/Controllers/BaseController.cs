using System.IdentityModel.Tokens.Jwt;
using MigrantProjectMVC.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MigrantProjectMVC.Controllers
{
    public class BaseController : Controller
    {
        public const string COOKIES_KEY_AUTH_TOKEN = "Auth";
        
        public const string URL_HOME = "../Home/Index";
        public const string URL_LOGIN = "../User/Login";
        public const string URL_REGISTER = "../User/Register";
        public const string URL_REGISTER_MIGRANT_DATA = "../Migrant/RegisterMigrantData";
        public const string URL_SHOW_REFFERAL = "../Refferal/ShowRefferal";
        public const string URL_SHOW_REFFERAL_FORM = "../Refferal/ShowRefferalForm";
        
        private ICommandProcessor _commandProcessor;
        private IQueryProcessor _queryProcessor;
        protected ICommandProcessor commandProcessor => _commandProcessor ??= HttpContext.RequestServices.GetRequiredService<ICommandProcessor>();
        protected IQueryProcessor queryProcessor => _queryProcessor ??= HttpContext.RequestServices.GetRequiredService<IQueryProcessor>();

        protected JwtSecurityToken GetJwtToken()
        {
            var token = HttpContext.Request.Cookies[COOKIES_KEY_AUTH_TOKEN];
            
            if (string.IsNullOrEmpty(token))
                return null;
            
            var jwtSecurityHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtSecurityHandler.ReadJwtToken(token);
            return jwtToken;
        }
    }
}
