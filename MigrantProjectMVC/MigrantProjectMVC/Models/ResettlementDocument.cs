namespace MigrantProjectMVC.Models
{
    [Serializable]
    public class ResettlementDocument : Document
    {
        public static ResettlementDocument Create()
        {
            return new ResettlementDocument() { Name = "ResettlementProgramMember" };
        }
    }
}