namespace MigrantProjectMVC.Queries
{
    public class GetStatementStatusQuery
    {
        public Guid StatementId { get; set; }
        
        public GetStatementStatusQuery(Guid statementId)
        {
            this.StatementId = statementId;
        }
    }
}
