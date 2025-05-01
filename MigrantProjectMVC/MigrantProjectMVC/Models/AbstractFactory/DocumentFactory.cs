namespace MigrantProjectMVC.Models.AbstractFactory
{
    public static class DocumentFactory
    {
        public static Document GetDocument(string documentName)
        {
            switch (documentName.ToLower())
            {
                case "highlyqualified":
                    return HighlyQualifiedDocument.Create();
                case "resettlementprogrammember":
                    return ResettlementDocument.Create();
                case "consistofmigrationprogram":
                    return ConsistOfMigrationProgramDocument.Create();
                default:
                    return null;
            }
        }
    }
}