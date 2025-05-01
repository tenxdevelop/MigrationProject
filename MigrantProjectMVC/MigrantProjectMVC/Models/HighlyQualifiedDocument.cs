namespace MigrantProjectMVC.Models
{
    [Serializable]
    public class HighlyQualifiedDocument : Document
    {
        public static HighlyQualifiedDocument Create()
        {
            return new HighlyQualifiedDocument() { Name = "HighlyQualified" };
        }

        public override bool Equals(Document other)
        {
            var otherDocument = other as HighlyQualifiedDocument;
            
            return Name.Equals(otherDocument.Name);
        }
    }
}