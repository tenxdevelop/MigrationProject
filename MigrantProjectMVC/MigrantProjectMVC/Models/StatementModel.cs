using MigrantProjectMVC.Enums;

namespace MigrantProjectMVC.Models
{
    public class StatementModel
    {
        public Guid Id { get; set; }
        public string AccountingAddress { get; set; }
        public string PreviousAddress { get; set; }
        public RegulationModel Regulation { get; set; }
        public UserModel PlaceOwner { get; set; }
        public List<DocumentModel> Documents { get; set; }
        public List<DocumentModel> MigrantDocuments { get; set; }
        public StatusType Status { get; set; }

        public static StatementModel Create(List<DocumentModel> documents, List<DocumentModel> migrantDocuments, string previousAddress, string accountingAddress)
        {
            return new StatementModel
            {
                Id = Guid.NewGuid(),
                AccountingAddress = accountingAddress,
                PreviousAddress = previousAddress,
                Documents = documents,
                MigrantDocuments = migrantDocuments,
            };

        }

    }
}
