using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.QueryHandlers
{
    public class GetRolesListQueryHandler : IQueryHandler<GetRolesListQuery, IList<RoleModel>>
    {

        IRoleRepostory _roleRepositry;
        public GetRolesListQueryHandler( IRoleRepostory roleRepostory) 
        {
            _roleRepositry = roleRepostory;
        }


        public async Task<IList<RoleModel>> Handle(GetRolesListQuery query)
        {
            return await _roleRepositry.GetAllRoles();
        }
    }
}
