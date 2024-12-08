using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.CommandHandlers
{
    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand, bool>
    {
        IUserRepository _repository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _repository = userRepository;
        }
        public async Task<bool> Handle(DeleteUserCommand requist)
        {
            await _repository.DeleteUser(requist.Id);
            return true;
        }
    }
}
