using MigrantProjectMVC.Application.Features.Services;
using MigrantProjectMVC.Interfaces.Services;
using MigrantProjectMVC.Repositories;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC
{
    public static class RegisterServices
    {
        public static void Register(WebApplicationBuilder builder)
        {
            //register other service
            builder.Services.AddSingleton<ITokenProvider, JwtTokenProvider>();
            builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
            
            //register repositories
            builder.Services.AddSingleton<IUserRepository, UserJsonPrefs>();
            builder.Services.AddSingleton<IMigrantRepository, MigrantJsonPrefs>();
            builder.Services.AddSingleton<ICountryRepository, CountryJsonPrefs>();
            builder.Services.AddSingleton<ITargetRepository, TargetJsonPrefs>();
            builder.Services.AddSingleton<INotificationRepository, NotificationJsonPrefs>();
            
            //register services
            builder.Services.AddSingleton<IUserService, UserService>();
            builder.Services.AddSingleton<IMigrantService, MigrantService>();
            builder.Services.AddSingleton<IRefferalService, RefferalService>();
        }
    }
}
