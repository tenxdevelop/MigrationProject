using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.QueryHandlers
{
    public class GetStatementListQueryHandler : IQueryHandler<GetStatementListQuery, List<StatementModel>>
    {
        public Task<List<StatementModel>> Handle(GetStatementListQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
