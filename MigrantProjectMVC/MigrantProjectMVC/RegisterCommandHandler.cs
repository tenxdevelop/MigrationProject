using MigrantProjectMVC.CommandHandlers;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Commands;

namespace MigrantProjectMVC
{
    public static class RegisterCommandHandler
    {
        public static void Register(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<ICommandProcessor>(factory =>
            {
                var commandProcessor = new CommandProcessor();
                commandProcessor.RegisterCommandHadnler(new LoginUserCommandHandler(factory.GetService<IUserRepository>(), factory.GetService<IPasswordHasher>(),
                    factory.GetService<ITokenProvider>()));
                commandProcessor.RegisterCommandHadnler(new RegisterUserCommandHandler(factory.GetService<IUserRepository>(), factory.GetService<IPasswordHasher>()));

                return commandProcessor;

            });
        }
    }
}
