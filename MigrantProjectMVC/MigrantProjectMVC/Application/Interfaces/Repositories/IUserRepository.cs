using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces
{
    public interface IUserRepository
    {
        public Task<bool> AddUser(UserModel user);
        public Task<UserModel> GetUserByEmail(string email);

        public Task<bool> IsHaveUserByEmail(string email);
    }
}
