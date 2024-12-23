using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Queries;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
            var unresolvedStatement = allStatements.Where(x => x.Status == StatusType.INPROCESS && x.MvdWorkerId == query.MvdWorkerId).FirstOrDefault();
            if (unresolvedStatement != null)
            {
                return unresolvedStatement;
            }

            var statement = allStatements.Where(x => x.Status == StatusType.CREATED).FirstOrDefault();
            if (statement != null) 
            {
                statement.Status = StatusType.INPROCESS;
                statement.MvdWorkerId = query.MvdWorkerId;
                await _statementRepository.SaveContext();
            } 

            return statement;
        }
    }
}
