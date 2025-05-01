using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC
{
    public static class RegisterQueryHandler
    {
        public static void Register(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IQueryProcessor>(sp =>
            {
                var queryProcessor = new QueryProcessor();
                //queryProcessor.RegisterQueryHandler(new GetUserListQueryHandler(sp.GetService<IUserRepository>()));
                return queryProcessor;
            });
        }
    }
}
