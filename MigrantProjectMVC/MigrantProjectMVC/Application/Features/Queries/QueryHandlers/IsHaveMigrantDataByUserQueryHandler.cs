using MigrantProjectMVC.Application.Features.Queries.Queries;
using MigrantProjectMVC.Interfaces.Services;
using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.Application.Features.Queries.QueryHandlers
{
    public class IsHaveMigrantDataByUserQueryHandler : IQueryHandler<IsHaveMigrantDataByUserQuery, bool>
    {
        private IMigrantService _migrantService;

        public IsHaveMigrantDataByUserQueryHandler(IMigrantService migrantService)
        {
            _migrantService = migrantService;
        }
        
        public async Task<bool> Handle(IsHaveMigrantDataByUserQuery query)
        {
            var result = await _migrantService.IsHaveMigrantData(query.UserId);
            return result;
        }
    }
}