using MigrantProjectMVC.Models.AbstractFactory;

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


        public static MigrantModel Create(Guid userId, string name, string surname, string patronymic, DateTime enteringDate, CountryModel country, List<string> documentNames)
        {
            var documents = new List<Document>();
            documentNames.ForEach(documentName => documents.Add(DocumentFactory.GetDocument(documentName)));
            
            return new MigrantModel() { UserId = userId, Name = name, Surname = surname, Patronymic = patronymic, EnteringDate = enteringDate, Country = country, Documents = documents };
        }
        
    }
}