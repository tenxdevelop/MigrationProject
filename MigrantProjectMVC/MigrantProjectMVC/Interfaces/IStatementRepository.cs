using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces
{
    public interface IStatementRepository
    {
        public Task<StatementModel> GetStatementById(Guid id);
        public Task<IList<StatementModel>> GetAllStatements();
        public Task<IList<StatementModel>> GetAllStatementsByPlaceOwnerId(Guid userId);
        public Task UpdateStatement(StatementModel statement);
        public Task Add(StatementModel statement);
    }
}
