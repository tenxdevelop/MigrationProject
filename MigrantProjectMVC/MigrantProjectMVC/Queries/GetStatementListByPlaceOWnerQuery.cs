using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Queries
{
    public class GetStatementListByPlaceOWnerQuery : IQuery<List<StatementModel>>
    {
        public Guid UserId { get; set; }

        public GetStatementListByPlaceOWnerQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
