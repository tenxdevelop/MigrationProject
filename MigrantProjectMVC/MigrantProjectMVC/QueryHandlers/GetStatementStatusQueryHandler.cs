using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.QueryHandlers
{
    public class GetStatementStatusQueryHandler : IQueryHandler<GetStatementStatusQuery, StatusType>
    {
        private IStatementRepository _statementRepository;

        public GetStatementStatusQueryHandler(IStatementRepository statementRepository)
        {
            _statementRepository = statementRepository;
        }

        public async Task<StatusType> Handle(GetStatementStatusQuery query)
        {
            var statement = await _statementRepository.GetStatementById(query.StatementId);
            return statement.Status;
        }
    }
}
