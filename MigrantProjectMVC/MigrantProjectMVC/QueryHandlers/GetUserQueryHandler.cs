using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.QueryHandlers
{
    public class GetUserQueryHandler : IQueryHandler<GetUserQuery, UserModel>
    {
        IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModel> Handle(GetUserQuery query)
        {
            var user = await _userRepository.GetUserBySNP(query.Surname, query.Name, query.Patronymic);
            return user;
        }
    }
}
