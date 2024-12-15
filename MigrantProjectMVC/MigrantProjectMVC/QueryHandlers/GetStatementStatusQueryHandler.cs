using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.QueryHandlers
{
    public class GetStatementStatusQueryHandler : IQueryHandler<GetStatementStatusQuery, StatusType>
    {
        public Task<StatusType> Handle(GetStatementStatusQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
