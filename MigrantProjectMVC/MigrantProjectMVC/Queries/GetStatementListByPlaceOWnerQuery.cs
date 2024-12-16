using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Queries
{
    public class GetStatementListQuery : IQuery<List<StatementModel>>
    {
        public Guid UserId { get; set; }

        public GetStatementListQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
