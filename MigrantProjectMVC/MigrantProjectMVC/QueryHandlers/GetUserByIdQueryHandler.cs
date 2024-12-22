using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.QueryHandlers
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserModel>
    {
        private IUserRepository _userRepository;
        public GetUserByIdQueryHandler(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public Task<UserModel> Handle(GetUserByIdQuery query)
        {
            return _userRepository.GetUserById(query.Id);
        }
    }
}
