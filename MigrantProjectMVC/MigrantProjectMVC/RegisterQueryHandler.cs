using MigrantProjectMVC.Application.Features.Queries.QueryHandlers;
using MigrantProjectMVC.Interfaces.Services;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC
{
    public static class RegisterQueryHandler
    {
        public static void Register(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IQueryProcessor>(factory =>
            {
                var queryProcessor = new QueryProcessor();
                queryProcessor.RegisterQueryHandler(new IsHaveMigrantDataByUserQueryHandler(factory.GetService<IMigrantService>()));
                queryProcessor.RegisterQueryHandler(new GetUserByEmailQueryHandler(factory.GetService<IUserService>()));
                
                return queryProcessor;
            });
        }
    }
}
