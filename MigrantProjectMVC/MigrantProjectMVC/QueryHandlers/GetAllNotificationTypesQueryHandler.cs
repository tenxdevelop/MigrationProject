using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.QueryHandlers
{
    public class GetAllNotificationTypesQueryHandler : IQueryHandler<GetAllNotificationTypesQuery, IList<string>>
    {
        public GetAllNotificationTypesQueryHandler() { }

        public Task<IList<string>> Handle(GetAllNotificationTypesQuery query)
        {
            var types = Enum.GetValues(typeof(NotificationType)).Cast<NotificationType>().Select(x => x.ToString()).ToList();
            return Task.FromResult(types as IList<string>);
        }
    }
}
