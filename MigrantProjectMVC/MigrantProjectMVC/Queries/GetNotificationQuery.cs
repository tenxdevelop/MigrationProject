namespace MigrantProjectMVC.Queries
{
    public class GetNotificationQuery
    {
        public Guid StatementId { get; set; }

        public GetNotificationQuery(Guid statementId)
        {
            StatementId = statementId;
        }
    }
}
