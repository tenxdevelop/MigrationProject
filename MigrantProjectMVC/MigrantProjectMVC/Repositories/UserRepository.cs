using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<UserModel> Users { get; set; }

        public UserRepository()
        {
            Users = new List<UserModel>() { new UserModel()
            {
                Id = 1,
                Name ="adw", 
                Surname = "dzx",
                Patronymic ="dq",
                Email = "ytqr",
                Password = "bncv"
            } };
        }
        public Task<bool> Add(UserModel user)
        { 
            Users.Add(user);
            return Task.FromResult(true);
        }
        public Task<bool> Remove(int id)
        {
            var user = Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                Users.Remove(user);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

       
    }
}
