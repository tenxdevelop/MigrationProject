using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Queries
{
    public class GetRegulationQuery : IQuery<RegulationModel>
    {
        public string Email { get; set; }

        public GetRegulationQuery(string email) 
        {
            Email = email;
        }

    }
}
