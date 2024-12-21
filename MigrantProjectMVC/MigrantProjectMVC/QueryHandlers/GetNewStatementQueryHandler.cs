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
            var statement = allStatements.Where(x => x.Status == StatusType.CREATED).FirstOrDefault();
            if (statement != null) 
            {
                statement.Status = StatusType.INPROCESS;
                await _statementRepository.SaveContext();
            } 

            return statement;
        }
    }
}
