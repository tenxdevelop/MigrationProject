using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.QueryHandlers
{
    public class GetMigrantQueryHandler : IQueryHandler<GetMigrantQuery, MigrantModel>
    {
        IMigrantRepository _migrantRepository;

        public GetMigrantQueryHandler(IMigrantRepository migrantRepository)
        {
            _migrantRepository = migrantRepository;
        }

        public async Task<MigrantModel> Handle(GetMigrantQuery query)
        {
            var migrant = await _migrantRepository.GetMigrantBySNP(query.Name, query.Surname, query.Patronimyc);
            return migrant;
        }
    }
}
