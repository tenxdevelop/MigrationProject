using Microsoft.AspNetCore.Identity;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.CommandHandlers
{
    public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, string>
    {
        private ITokenProvider _tokenProvider;
        private IPasswordHasher _passwordHasher;
        private IUserRepository _userRepository;
        public LoginUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasker, ITokenProvider tokenProvider)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasker;
            _tokenProvider = tokenProvider;
        }
        public Task<string> Handle(LoginUserCommand requist)
        {
            throw new NotImplementedException();
        }
    }
}
