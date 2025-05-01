namespace MigrantProjectMVC.Models
{
    [Serializable]
    public class HighlyQualifiedDocument : Document
    {
        public static HighlyQualifiedDocument Create()
        {
            return new HighlyQualifiedDocument() { Name = "HighlyQualified" };
        }
    }
}