using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using System.Text.Json;

namespace MigrantProjectMVC.Repositories
{
    public class StatementRepository : IStatementRepository
    {
        public List<StatementModel> Statements;
        private string _filePath = "jsons/statements.json";
        public StatementRepository()
        {
            using (var fs = new FileStream(_filePath, FileMode.Open))
            {
                try
                {
                    Statements = JsonSerializer.Deserialize<List<StatementModel>>(fs);
                }
                catch (Exception e)
                {
                    Statements = new List<StatementModel>()
                    {

                    };
                }
            }
        }



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
