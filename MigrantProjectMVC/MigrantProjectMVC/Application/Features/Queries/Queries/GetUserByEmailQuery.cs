using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Application.Features.Queries.Queries
{
    public class GetUserByEmailQuery : IQuery<UserModel>
    {
        public string Email { get; private set; }

        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
    }
}