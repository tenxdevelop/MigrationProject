using MigrantProjectMVC.Interfaces.Services;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Commands;

namespace MigrantProjectMVC.CommandHandlers
{

    public class RegisterMigrantCommandHandler : ICommandHandler<RegisterMigrantCommand, bool>
    {

        private IMigrantService _migrantService;

        public RegisterMigrantCommandHandler(IMigrantService migrantService)
        {
            _migrantService = migrantService;
        }
        
        public async Task<bool> Handle(RegisterMigrantCommand requist)
        {
            var result = await _migrantService.RegisterMigrant(requist.UserId, requist.Name, requist.Surname, requist.Patronymic, requist.EnteringDate, requist.CountryName, requist.DocumentNames);
            return result;
        }
    }
}