using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Repositories
{
    public class StatementRepository : IStatementRepository
    {
        public List<StatementModel> Statements;

        public Task<IList<StatementModel>> GetAllStatementsByPlaceOwner(Guid userId)
        {
            return Task.FromResult(Statements.Where(x => x.PlaceOwner.Id == userId) as IList<StatementModel>);
        }

        public Task<StatusType> GetStatementStatus(Guid statementId)
        {
            return Task.FromResult(Statements.FirstOrDefault(x => x.Id == statementId).Status);
        }

        public Task<IList<StatementModel>> GetAllStatements()
        {
            return Task.FromResult(Statements as IList<StatementModel>);
        }

        public Task UpdateStatement(StatementModel statement)
        {
            var foundedStatement = Statements.FirstOrDefault(x => x.Id == statement.Id);
            if (foundedStatement == null) return Task.CompletedTask;
            foundedStatement.Status = statement.Status;
            foundedStatement.Documents = statement.Documents;
            foundedStatement.MigrantDocuments = statement.MigrantDocuments;
            foundedStatement.Regulation = statement.Regulation;
            foundedStatement.AccountingAddress = statement.AccountingAddress;
            foundedStatement.PlaceOwner = statement.PlaceOwner;
            foundedStatement.PreviousAddress = statement.PreviousAddress;
            return Task.CompletedTask;

        }

        public Task Add(StatementModel statement)
        {
            Statements.Add(statement);
            return Task.CompletedTask;
        }
    }
}
