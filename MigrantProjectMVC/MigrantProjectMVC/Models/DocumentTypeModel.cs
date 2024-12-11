namespace MigrantProjectMVC.Models
{
    public class DocumentTypeModel
    {
        public string Name { get; set; }
        public static DocumentTypeModel Create(string name)
        {
            return new DocumentTypeModel
            {
                Name = name
            };
        }
    }
}
