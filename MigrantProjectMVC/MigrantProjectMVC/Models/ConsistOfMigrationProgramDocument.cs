namespace MigrantProjectMVC.Models
{
    public class ConsistOfMigrationProgramDocument : Document
    {
        public static ConsistOfMigrationProgramDocument Create()
        {
            return new ConsistOfMigrationProgramDocument() { Name = "ConsistOfMigrationProgram" };
        }
    }
}