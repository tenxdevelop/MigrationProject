using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.CommandHandlers
{
    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand, bool>
    {
        private IUserRepository _repository;
        private IMigrantRepository _migrantRepository;
        public DeleteUserCommandHandler(IUserRepository userRepository, IMigrantRepository migrantRepository)
        {
            _repository = userRepository;
            _migrantRepository = migrantRepository;
        }
        public async Task<bool> Handle(DeleteUserCommand requist)
        {
            await _migrantRepository.DeleteMigrant(requist.Id);
            await _repository.DeleteUser(requist.Id);
            await _repository.SaveContext();
            return true;
        }
    }
}
