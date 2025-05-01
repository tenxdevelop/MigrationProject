using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.Application.Features.Queries.Queries
{
    public class IsHaveMigrantDataByUserQuery :  IQuery<bool>
    {
        public Guid UserId { get; private set; }

        public IsHaveMigrantDataByUserQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}