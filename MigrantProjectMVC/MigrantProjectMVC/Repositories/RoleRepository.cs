using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Repositories
{
    public class RoleRepository : IRoleRepostory
    {
        public List<RoleModel> Roles { get; set; }
        public RoleRepository() { }

        public Task<IList<RoleModel>> GetAllRoles()
        {
            return Task.FromResult(Roles as IList<RoleModel>);
        }
    }
}
