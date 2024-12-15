using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces
{
    public interface IRoleRepostory
    {
        public Task<IList<RoleModel>> GetAllRoles();
    }
}
