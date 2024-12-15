using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces
{
    public interface IUserRepository
    {
        public Task<bool> Add(UserModel user);
        public Task<bool> DeleteUser(Guid id);

        public Task<UserModel> GetUserByEmail(string email);
        public Task<UserModel> GetUserByPhone(string phone);
        public Task<List<UserModel>> GetAllUsers();
        public Task UpdateUserData(UserModel user);
        public Task<UserModel> GetUserBySNP(string surname, string name, string patronymic);

        public Task SaveContext();

    }
}
