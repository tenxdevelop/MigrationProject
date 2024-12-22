using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.CommandHandlers
{
    public class SetStatementStatusCommandHandler : ICommandHandler<SetStatementStatusCommand, bool>
    {
        private IStatementRepository _statementRepository;

        public SetStatementStatusCommandHandler(IStatementRepository statementRepository)
        {
            _statementRepository = statementRepository;
        }

        public async Task<bool> Handle(SetStatementStatusCommand requist)
        {
            var statement = await _statementRepository.GetStatementById(requist.Id);
            if (statement == null) return false;
            statement.Status = requist.Status;
            _statementRepository.SaveContext();
            return true;
        }
    }
}
