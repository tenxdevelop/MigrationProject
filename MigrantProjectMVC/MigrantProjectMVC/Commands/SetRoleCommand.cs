using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using System.Windows.Input;

namespace MigrantProjectMVC.Commands
{
    public class SetRoleCommand : ICommand<bool>
    {
        public Guid Id;
        public RoleModel Role;

        public SetRoleCommand(Guid id, RoleModel role)
        {
            Id = id;
            Role = role;
        }
    }
}
