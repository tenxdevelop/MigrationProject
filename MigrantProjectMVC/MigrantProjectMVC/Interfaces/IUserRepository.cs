using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces
{
    public interface IUserRepository
    {
        public Task<bool> Add(UserModel user);
        public Task<bool> Remove(int id);
    }
}
