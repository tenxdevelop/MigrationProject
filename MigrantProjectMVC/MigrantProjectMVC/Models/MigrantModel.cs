namespace MigrantProjectMVC.Models
{
    public class MigrantModel : UserModel
    {
        public DateTime EnteringDate { get; set; }
        public bool HighlyQualified { get; set; }
        public bool ResettelmentProgramMember { get; set; }
        public bool ConsistOfMigrationRegistration { get; set; }
        public string Country { get; set; }

    }
}
