using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.QueryHandlers
{
    public class GetNewStatementQueryHandler : IQueryHandler<GetNewStatementQuery, StatementModel>
    {
        private IStatementRepository _statementRepository;

        public GetNewStatementQueryHandler(IStatementRepository statementRepository)
        {
            _statementRepository = statementRepository;
        }

        public async Task<StatementModel> Handle(GetNewStatementQuery query)
        {
            var allStatements = await _statementRepository.GetAllStatements();
            var statment = allStatements.Where(x => x.Status == StatusType.CREATED).FirstOrDefault();
            return statment;
        }
    }
}
