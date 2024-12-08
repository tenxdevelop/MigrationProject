using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.QueryHandlers
{
    public class GetUserListQueryHandler : IQueryHandler<GetUserListQuery, List<UserModel>>
    {
        IUserRepository _userRepository;
        public GetUserListQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserModel>> Handle(GetUserListQuery query)
        {
            return await _userRepository.GetAllUsers();
        }
    }
}
