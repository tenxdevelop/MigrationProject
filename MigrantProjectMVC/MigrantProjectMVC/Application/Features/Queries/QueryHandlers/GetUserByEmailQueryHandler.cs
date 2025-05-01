using MigrantProjectMVC.Application.Features.Queries.Queries;
using MigrantProjectMVC.Interfaces.Services;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Application.Features.Queries.QueryHandlers
{

    public class GetUserByEmailQueryHandler : IQueryHandler<GetUserByEmailQuery, UserModel>
    {
        private IUserService _userService;
        
        public GetUserByEmailQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        
        public async Task<UserModel> Handle(GetUserByEmailQuery query)
        {
            var user = await _userService.GetUserByEmail(query.Email);
            return user;
        }
    }
}