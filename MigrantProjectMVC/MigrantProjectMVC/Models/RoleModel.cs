namespace MigrantProjectMVC.Models
{
    public class RoleModel
    {
        public string Name { get; set; }
        
        public static RoleModel GetDefaultRole()
        {
            return new RoleModel() {Name = "Migrant" };
        }
    }
}