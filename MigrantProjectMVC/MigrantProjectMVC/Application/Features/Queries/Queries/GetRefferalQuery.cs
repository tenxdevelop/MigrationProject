using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.ViewModel;

namespace MigrantProjectMVC.Application.Features.Queries.Queries
{
    public class GetRefferalQuery : IQuery<RefferalViewModel>
    {
        public string TargetName { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Patronymic { get; private set; }
        public GetRefferalQuery(string targetName, string name, string surname, string patronymic)
        {
            TargetName = targetName;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
        }
    }
}