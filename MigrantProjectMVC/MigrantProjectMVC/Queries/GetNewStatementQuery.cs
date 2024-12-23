using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Queries
{
    public class GetNewStatementQuery : IQuery<StatementModel>
    {
        public Guid MvdWorkerId {get;set;}

        public GetNewStatementQuery(Guid mvdWorkerId)
        {
            MvdWorkerId = mvdWorkerId;
        }
    }
}
