using MigrantProjectMVC.ViewModel;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces.Services
{
     public interface IUserService
     {
          Task<string> LoginUser(string email, string password);

          Task<RegisterViewModel> RegisterUser(string email, string password);

          Task<UserModel> GetUserByEmail(string email);
     }
}