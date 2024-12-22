using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using System.Text.Json;

namespace MigrantProjectMVC.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<UserModel> Users { get; set; }
        UserModel User { get; set; }
        string _filePath = "jsons/users.json";
        IPasswordHasher _passwordHasher { get; set; }

        public UserRepository(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
            using (var fs = new FileStream(_filePath, FileMode.Open))
            {
                try
                {
                    Users = JsonSerializer.Deserialize<List<UserModel>>(fs);
                }
                catch (Exception ex) 
                {
                    Users = new List<UserModel>();   
                }
            }
        }
        public Task<bool> Add(UserModel user)
        { 
            user.PasswordHash = _passwordHasher.GenerateHash(user.PasswordHash);
            Users.Add(user);
            var lines = Users.Select(x => $"{user.Id};{user.Name};{user.Surname};{user.Patronymic};{user.Email};{user.Phone};{user.PasswordHash};{user.Role}").ToArray();
            using (var fs = new FileStream(_filePath, FileMode.Open))
            {
                JsonSerializer.Serialize(fs, Users);
            }

            return Task.FromResult(true);
        }
        public Task<bool> DeleteUser(Guid id)
        {
            var user = Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                Users.Remove(user);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<UserModel> GetUserByEmail(string email)
        {
            User = Users.FirstOrDefault(x => x.Email == email);
            return Task.FromResult(User);
            
        }

        public Task<UserModel> GetUserByPhone(string phone)
        {
            User = Users.FirstOrDefault(x => x.Phone == phone);
            return Task.FromResult(User);
        }

        public Task<List<UserModel>> GetAllUsers()
        {
            return Task.FromResult(Users);
        }

        public Task UpdateUserData(UserModel user)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetUserBySNP(string surname, string name, string patronymic)
        {
            var user = Users.FirstOrDefault(x => x.Name == name &&
                                           x.Surname == surname &&
                                           x.Patronymic == patronymic);
            return Task.FromResult(user);
        }

        public Task SaveContext()
        {
            var jsonData = JsonSerializer.Serialize(Users);
            File.WriteAllText(_filePath, jsonData);
            return Task.CompletedTask;
        }

        public Task<UserModel> GetUserById(Guid id)
        {
            var user = Users.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(user);
        }
    }
}
