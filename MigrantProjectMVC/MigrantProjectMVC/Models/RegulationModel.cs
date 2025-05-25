namespace MigrantProjectMVC.Models
{
    [Serializable]
    public class RegulationModel
    {
        public int Term { get; set; }
        public string Name { get; set; }
        public List<CountryModel> Countries { get; set; }
        public List<Document> UseDocuments { get; set; }

        public bool IsValidRegulation(MigrantModel migrant)
        {
            var migrantDocuments = migrant.Documents;

            if ((DateTime.Now - migrant.EnteringDate).TotalDays - Term > 0)
                return false;
            
            if(Countries.Count > 0  && !Countries.Contains(migrant.Country))
                return false;

            foreach (var useDocument in UseDocuments)
            {
                if(!ContainsDocument(useDocument, migrantDocuments))
                    return false;
            }
            
            return true;
        }

        public void Update(List<CountryModel> countries, List<Document> useDocuments, int term)
        {
            Term = term;
            Countries = countries;
            UseDocuments = useDocuments;
        }
        
        private bool ContainsDocument(Document useDocument, List<Document> migrantDocuments)
        {
            foreach (var migrantDocument in migrantDocuments)
            {
                if (migrantDocument.Equals(useDocument))
                    return true;
            }
        
            return false;
        }
    }
    
    
}