
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.CommandHandlers
{
    public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, string>
    {
        private ITokenProvider _tokenProvider;
        private IPasswordHasher _passwordHasher;
        private IUserRepository _userRepository;
        
        public LoginUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, ITokenProvider tokenProvider)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenProvider = tokenProvider;
        }
        public async Task<string> Handle(LoginUserCommand requist)
        {
            UserModel user = await _userRepository.GetUserByEmail(requist.Email);

            if (user is null) 
                return null;

            if (!_passwordHasher.Verify(requist.Password, user.PasswordHash)) 
                return null;
   
            var token = _tokenProvider.GenerateToken(user);
            
            return token; 
        }
    }
}
