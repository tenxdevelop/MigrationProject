using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Queries
{
    public class GetStatementStatusQuery : IQuery<StatusType> 
    {
        public Guid StatementId { get; set; }
        
        public GetStatementStatusQuery(Guid statementId)
        {
            this.StatementId = statementId;
        }
    }
}
