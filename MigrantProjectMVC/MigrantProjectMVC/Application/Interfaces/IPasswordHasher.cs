namespace MigrantProjectMVC.Interfaces
{
    public interface IPasswordHasher
    {
        public string GenerateHash(string password);
        public bool Verify(string password, string passwordHash);
    }
}
