using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using System.Text.Json;

namespace MigrantProjectMVC.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<UserModel> Users { get; set; }
        UserModel User { get; set; }
        string _filePath = "users.json";
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
            //if (!File.Exists(_filePath))
            //{
            //    return;
            //}

            //var lines = File.ReadAllLines(_filePath);

            //foreach (var line in lines)
            //{
            //    var parts = line.Split(';');
            //    if (parts.Length == 8)
            //    {
            //        Users.Add(new UserModel
            //        {
            //            Id = Convert.ToInt32(parts[0]),
            //            Name = parts[1],
            //            Surname = parts[2],
            //            Patronymic = parts[3],
            //            Email = parts[4],
            //            Phone = parts[5],
            //            Password = parts[6],
            //            Role = parts[7]
            //        });
            //    }
            //}
        }
        public Task<bool> Add(UserModel user)
        { 
            user.Password = _passwordHasher.GenerateHash(user.Password);
            Users.Add(user);
            //var lines = Users.Select(x => $"{user.Id};{user.Name};{user.Surname};{user.Patronymic};{user.Email};{user.Phone};{user.Password};{user.Role}").ToArray();
            //File.WriteAllLines(_filePath, lines);
            var data = JsonSerializer.Serialize(Users);
            File.WriteAllText(_filePath, data);
            return Task.FromResult(true);
        }
        public Task<bool> DeleteUser(int id)
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
            throw new NotImplementedException();
        }
    }
}
