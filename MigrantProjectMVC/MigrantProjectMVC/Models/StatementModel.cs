using MigrantProjectMVC.Enums;

namespace MigrantProjectMVC.Models
{
    public class StatementModel
    {
        public Guid Id { get; set; }
        public string AccountingAddress { get; set; }
        public string PreviousAddress { get; set; }
        public RegulationModel Regulation { get; set; }
        public Guid MvdWorkerId { get; set; }
        public MigrantModel Migrant { get; set; }

        public UserModel PlaceOwner { get; set; }
        public List<DocumentModel> Documents { get; set; }
        public List<DocumentModel> MigrantDocuments { get; set; }
        public StatusType Status { get; set; }

        public static StatementModel Create(List<DocumentModel> documents, List<DocumentModel> migrantDocuments, string previousAddress, string accountingAddress, 
                                            StatusType status, UserModel placeOwner, RegulationModel regulation, MigrantModel migrant)
        {
            return new StatementModel
            {
                Id = Guid.NewGuid(),
                Status = status,
                AccountingAddress = accountingAddress,
                PreviousAddress = previousAddress,
                Documents = documents,
                Migrant = migrant,
                MigrantDocuments = migrantDocuments,
                PlaceOwner = placeOwner,
                Regulation = regulation
            };

        }

    }
}
