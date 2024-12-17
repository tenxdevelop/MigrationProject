using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.QueryHandlers
{
    public class GetAllStatementsQueryHandler : IQueryHandler<GetAllStatementsQuery, IList<StatementModel>>
    {
        private IStatementRepository _statementRepository;
        public GetAllStatementsQueryHandler(IStatementRepository statementRepository) 
        {
            _statementRepository = statementRepository;
        }

        public Task<IList<StatementModel>> Handle(GetAllStatementsQuery query)
        {
            return _statementRepository.GetAllStatements();
        }
    }
}
