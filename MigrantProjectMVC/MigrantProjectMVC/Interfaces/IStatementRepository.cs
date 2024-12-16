using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces
{
    public interface IStatementRepository
    {
        public Task<StatementModel> GetStatementById(Guid id);
    }
}
