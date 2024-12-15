using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Queries
{
    public class GetMigrantQuery : IQuery<MigrantModel>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronimyc { get; set; }

        public GetMigrantQuery(string name, string surname, string patronymic)
        {
            Name = name;
            Surname = surname;
            Patronimyc = patronymic;
        }
    }
}
