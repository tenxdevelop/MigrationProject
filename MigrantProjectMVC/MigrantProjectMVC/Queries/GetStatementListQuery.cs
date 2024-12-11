namespace MigrantProjectMVC.Queries
{
    public class GetStatementListQuery
    {
        public Guid UserId { get; set; }

        public GetStatementListQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
