using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.QueryHandlers
{
    public class GetAllStatementsQueryHandler : IQueryHandler<GetAllStatementsQuery, IList<StatementModel>>
    {
        private IStatementRepository _statementRepositoryl;
        public GetAllStatementsQueryHandler(IStatementRepository statementRepository) 
        {
            _statementRepositoryl = statementRepository;
        }


    }
}
