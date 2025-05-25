
namespace MigrantProjectMVC.Models
{
    [Serializable]
    public class MigrantModel
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public DateTime EnteringDate { get; set; }
        
        public CountryModel Country { get; set; }

        public List<Document> Documents { get; set; }
        
        public MigrantModel(Guid userId, string name, string surname, string patronymic, DateTime enteringDate, CountryModel country, List<Document> documents)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            EnteringDate = enteringDate;
            Country = country;
            Documents = documents;
        }

        public string GetFIO()
        {
            return Surname + " " + Name + " " + Patronymic + " ";
        }
    }
}