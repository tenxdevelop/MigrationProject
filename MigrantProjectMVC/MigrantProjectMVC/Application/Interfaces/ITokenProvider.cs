using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces
{
    public interface ITokenProvider
    {
        public string GenerateToken(UserModel user);
    }
}