using MigrantProjectMVC.Interfaces;
using System.Windows.Input;

namespace MigrantProjectMVC.Commands
{
    public class DeleteUserCommand : ICommand<bool>
    {
        public int Id { get; set; }
        public DeleteUserCommand(int Id)
        {
            this.Id = Id;
        }
    }
}
