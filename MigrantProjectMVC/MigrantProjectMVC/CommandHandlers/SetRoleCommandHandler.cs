using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.CommandHandlers
{
    public class SetRoleCommandHandler : ICommandHandler<SetRoleCommand, bool>
    {
        IUserRepository _userRepository;

        public SetRoleCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(SetRoleCommand requist)
        {
            var user = _userRepository.GetAllUsers().Result.FirstOrDefault(x => x.Id == requist.Id);
            if (user == null) 
            {
                return false;
            }
            user.Role = requist.Role;
            await _userRepository.SaveContext();
            return true;
        }
    }
}
