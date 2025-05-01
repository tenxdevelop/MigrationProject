using MigrantProjectMVC.Models.JsonPrefs.Base;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Repositories
{
    public class UserRepository : JsonPrefs<List<UserModel>>, IUserRepository
    {
        private const string FILE_PATH = "jsons/users.json";
        
        private List<UserModel> _users;
        
        public UserRepository() : base(FILE_PATH)
        {
            _users = LoadFromJson();
        }
        
        public Task<bool> AddUser(UserModel user)
        {
            _users.Add(user);
            var resultSave = SaveToJson(_users);
            
            return Task.FromResult(resultSave);
        }
        public Task<UserModel> GetUserByEmail(string email)
        {
            var user = _users.Where(user => user.Email.Equals(email)).FirstOrDefault();
            
            return Task.FromResult(user);
        }
        
    }
}
