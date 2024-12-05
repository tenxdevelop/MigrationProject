using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.Models
{
    public class PasswordHasher : IPasswordHasher
    {
        public string GenerateHash(string password)
        {
            throw new NotImplementedException();
        }

        public bool Verify(string password, string passwordHash)
        {
            throw new NotImplementedException();
        }
    }
}
