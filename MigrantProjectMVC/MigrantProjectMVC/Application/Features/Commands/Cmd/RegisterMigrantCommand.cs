using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.Commands
{

    public class RegisterMigrantCommand : ICommand<bool>
    {
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Patronymic { get; private set; }
        public DateTime EnteringDate { get; private set; }
        public string CountryName { get; private set; }
        public List<string> DocumentNames { get; private set; }

        public RegisterMigrantCommand(Guid userId, string name, string surname, string patronymic, DateTime enteringDate, string countryName, List<string> documentNames)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            EnteringDate = enteringDate;
            CountryName = countryName;
            DocumentNames = documentNames;
        }
    }
}