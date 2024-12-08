using Microsoft.AspNetCore.Identity;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using System.Web;
namespace MigrantProjectMVC.CommandHandlers
{
    public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, string>
    {
        private ITokenProvider _tokenProvider;
        private IPasswordHasher _passwordHasher;
        private IUserRepository _userRepository;
        private  IHttpContextAccessor _httpContextAccessor;

        public LoginUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasker, ITokenProvider tokenProvider, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasker;
            _tokenProvider = tokenProvider;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> Handle(LoginUserCommand requist)
        {
            UserModel user = requist.Email == null ? await _userRepository.GetUserByPhone(requist.Phone) : await _userRepository.GetUserByEmail(requist.Email);

            if (user == null) return null;
   
            var token = _tokenProvider.GenerateToken(user);
            
            return token; 
        }
    }
}
