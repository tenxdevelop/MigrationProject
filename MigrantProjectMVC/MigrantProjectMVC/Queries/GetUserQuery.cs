using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Queries
{
    public class GetUserQuery : IQuery<UserModel>
    {
        public string Name;
        public string Surname;
        public string Patronymic;

        public GetUserQuery(string name, string surname, string patronymic) 
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
        }
    }
}
