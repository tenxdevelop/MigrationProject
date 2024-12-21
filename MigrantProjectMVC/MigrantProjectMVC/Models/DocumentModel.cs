namespace MigrantProjectMVC.Models
{
    public class DocumentModel
    {
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public DocumentTypeModel DocumentType { get; set; }
        public static DocumentModel Create(Guid id, DocumentTypeModel type, string name, string content, DateTime creationDate)
        {
            return new DocumentModel 
            { 
                OwnerId = id,
                DocumentType = type,
                Name = name,
                Content = content, 
                CreationDate = creationDate 
            };
        }
    }
}
