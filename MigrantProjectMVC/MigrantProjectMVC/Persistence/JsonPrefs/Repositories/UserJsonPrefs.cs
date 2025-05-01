using MigrantProjectMVC.Models.JsonPrefs.Base;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Repositories
{
    public class UserJsonPrefs : JsonPrefs<List<UserModel>>, IUserRepository
    {
        private const string FILE_PATH = "jsons/users.json";
        
        private List<UserModel> _users;
        
        public UserJsonPrefs() : base(FILE_PATH)
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

        public async Task<bool> IsHaveUserByEmail(string email)
        {
            var user = await GetUserByEmail(email);
            var result = user is not null;
            return result;
        }
    }
}
