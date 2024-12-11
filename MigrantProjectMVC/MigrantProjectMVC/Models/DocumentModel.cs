namespace MigrantProjectMVC.Models
{
    public class DocumentModel
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public DocumentTypeModel DocumentType { get; set; }
        public static DocumentModel Create(DocumentTypeModel type, string name, string content, DateTime creationDate)
        {
            return new DocumentModel 
            { 
                DocumentType = type,
                Name = name,
                Content = content, 
                CreationDate = creationDate 
            };
        }
    }
}
