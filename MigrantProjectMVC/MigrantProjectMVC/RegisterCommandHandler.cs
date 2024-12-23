using MigrantProjectMVC.CommandHandlers;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC
{
    public static class RegisterCommandHandler
    {
        public static void Register(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<ICommandProcessor>(sp =>
            {
                var commandProcessor = new CommandProcessor();
                commandProcessor.RegisterCommandHadnler(new CreateUserStatementCommandHandler(sp.GetService<IUserRepository>()));
                commandProcessor.RegisterCommandHadnler(new DeleteUserCommandHandler(sp.GetService<IUserRepository>(), sp.GetService<IMigrantRepository>()));
                commandProcessor.RegisterCommandHadnler(new LoginUserCommandHandler(sp.GetService<IUserRepository>(), sp.GetService<IPasswordHasher>(),
                        sp.GetService<ITokenProvider>(), sp.GetService<IHttpContextAccessor>()));
                commandProcessor.RegisterCommandHadnler(new RegisterUserCommandHandler(sp.GetService<IUserRepository>(), sp.GetService<IMigrantRepository>()));
                commandProcessor.RegisterCommandHadnler(new SetRoleCommandHandler(sp.GetService<IUserRepository>(), sp.GetService<IMigrantRepository>()));
                commandProcessor.RegisterCommandHadnler(new UpdateDataMigrantCommandHandler(sp.GetService<IMigrantRepository>()));
                commandProcessor.RegisterCommandHadnler(new UpdateRegulationTermCommandHandler(sp.GetService<IRegulationRepository>()));
                commandProcessor.RegisterCommandHadnler(new CreateDocumentCommandHandler(sp.GetService<IDocumentRepository>()));
                commandProcessor.RegisterCommandHadnler(new SetStatementStatusCommandHandler(sp.GetService<IStatementRepository>()));
                commandProcessor.RegisterCommandHadnler(new CreateNotificationCommandHandler(sp.GetService<INotificationRepository>(), sp.GetService<IStatementRepository>()));
                commandProcessor.RegisterCommandHadnler(new CreateStatementCommandHandler(sp.GetService<IStatementRepository>(), sp.GetService<IMigrantRepository>(),
                                                                                          sp.GetService<IDocumentRepository>(), sp.GetService<IRegulationRepository>()));
                commandProcessor.RegisterCommandHadnler(new SendNotificationCommandHandler(sp.GetService<IUserRepository>(), sp.GetService<INotificationRepository>()));
                commandProcessor.RegisterCommandHadnler(new SetNotificationTypeCommandHandler(sp.GetService<INotificationRepository>()));
                return commandProcessor;

            });
        }
    }
}
