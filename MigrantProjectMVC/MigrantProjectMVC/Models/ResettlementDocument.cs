namespace MigrantProjectMVC.Models
{
    [Serializable]
    public class ResettlementDocument : Document
    {
        public static ResettlementDocument Create()
        {
            return new ResettlementDocument() { Name = "ResettlementProgramMember" };
        }

        public override bool Equals(Document other)
        {
            var otherDocument = other as ResettlementDocument;
            
            return Name.Equals(otherDocument.Name);
        }
    }
}