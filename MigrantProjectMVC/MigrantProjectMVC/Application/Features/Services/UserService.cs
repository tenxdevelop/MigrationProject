using MigrantProjectMVC.Interfaces.Services;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.ViewModel;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Application.Features.Services
{
    public class UserService : IUserService
    {
        private IPasswordHasher _passwordHasher;
        private IUserRepository _userRepository;
        private ITokenProvider _tokenProvider;

        public UserService(IPasswordHasher passwordHasher, IUserRepository userRepository, ITokenProvider tokenProvider)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _tokenProvider = tokenProvider;
        }

        public async Task<string> LoginUser(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);

            if (user is null)
                return null;

            if (!_passwordHasher.Verify(password, user.PasswordHash))
                return null;

            var token = _tokenProvider.GenerateToken(user);

            return token;
        }

        public async Task<RegisterViewModel> RegisterUser(string email, string password)
        {
            var passwordHash = _passwordHasher.GenerateHash(password);
            
            var isHaveUserByEmail = await _userRepository.IsHaveUserByEmail(email);

            if (isHaveUserByEmail)
                return RegisterViewModel.Create(false, $"пользователь с почтой: {email}, уже существует в системе");
            
            var user = UserModel.Create(Guid.NewGuid(), email, passwordHash);
            
            var result = await _userRepository.AddUser(user);
            
            return RegisterViewModel.Create(result, string.Empty);
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            return user;
        }
    }
}