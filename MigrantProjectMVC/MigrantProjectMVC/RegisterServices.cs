using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Repositories;

namespace MigrantProjectMVC
{
    public static class RegisterServices
    {
        public static void Register(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<ITokenProvider, JwtTokenProvider>();
            builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
        }
    }
}
