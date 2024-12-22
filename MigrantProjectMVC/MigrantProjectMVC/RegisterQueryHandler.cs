using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Queries;
using MigrantProjectMVC.QueryHandlers;

namespace MigrantProjectMVC
{
    public static class RegisterQueryHandler
    {
        public static void Register(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IQueryProcessor>(sp =>
            {
                var queryProcessor = new QueryProcessor();
                queryProcessor.RegisterQueryHandler(new GetUserListQueryHandler(sp.GetService<IUserRepository>()));
                queryProcessor.RegisterQueryHandler(new GetUserQueryHandler(sp.GetService<IUserRepository>()));
                queryProcessor.RegisterQueryHandler(new GetRegulationListQueryHandler(sp.GetService<IRegulationRepository>()));
                queryProcessor.RegisterQueryHandler(new GetRegulationQueryHandler(sp.GetService<IMigrantRepository>(), sp.GetService<IRegulationRepository>()));
                queryProcessor.RegisterQueryHandler(new GetRolesListQueryHandler(sp.GetService<IRoleRepostory>()));
                queryProcessor.RegisterQueryHandler(new GetMigrantQueryHandler(sp.GetService<IMigrantRepository>()));
                queryProcessor.RegisterQueryHandler(new GetDocumentListQueryHandler(sp.GetService<IDocumentRepository>()));
                queryProcessor.RegisterQueryHandler(new GetAllStatementsQueryHandler(sp.GetService<IStatementRepository>()));
                queryProcessor.RegisterQueryHandler(new GetNewStatementQueryHandler(sp.GetService<IStatementRepository>()));
                queryProcessor.RegisterQueryHandler(new GetStatementListByPlaceOwnerQueryHandler(sp.GetService<IStatementRepository>()));
                queryProcessor.RegisterQueryHandler(new GetStatementStatusQueryHandler(sp.GetService<IStatementRepository>()));
                queryProcessor.RegisterQueryHandler(new GetMigrantByIdQueryHandler(sp.GetService<IMigrantRepository>()));
                queryProcessor.RegisterQueryHandler(new GetUserByIdQueryHandler(sp.GetService<IUserRepository>()));
                queryProcessor.RegisterQueryHandler(new GetAllNotificationQueryHandler(sp.GetService<INotificationRepository>()));
                queryProcessor.RegisterQueryHandler(new GetNotificationQueryHandler(sp.GetService<INotificationRepository>()));
                return queryProcessor;
            });
        }
    }
}
