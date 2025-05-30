namespace MigrantProjectMVC.Models
{
    [Serializable]
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public RoleModel Role { get; set; }

        public static UserModel Create(Guid id, string email, string passwordHash)
        {
            var role = RoleModel.GetDefaultRole(); 
            return new UserModel() { Id = id, Email = email, PasswordHash = passwordHash, Role = role };
        }
    }
}