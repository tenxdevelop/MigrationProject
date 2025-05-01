namespace MigrantProjectMVC.Models
{
    [Serializable]
    public class ConsistOfMigrationProgramDocument : Document
    {
        public static ConsistOfMigrationProgramDocument Create()
        {
            return new ConsistOfMigrationProgramDocument() { Name = "ConsistOfMigrationProgram" };
        }

        public override bool Equals(Document other)
        {
            var otherDocument = other as ConsistOfMigrationProgramDocument;

            return Name.Equals(otherDocument.Name);
        }
    }
}