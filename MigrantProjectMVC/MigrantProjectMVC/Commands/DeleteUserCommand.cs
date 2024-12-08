using MigrantProjectMVC.Interfaces;
using System.Windows.Input;

namespace MigrantProjectMVC.Commands
{
    public class DeleteUserCommand : ICommand<bool>
    {
        public Guid Id { get; set; }
        public DeleteUserCommand(Guid Id)
        {
            this.Id = Id;
        }
    }
}
