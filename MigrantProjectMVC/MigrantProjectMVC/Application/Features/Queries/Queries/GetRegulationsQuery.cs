using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Application.Features.Queries.Queries
{
    public class GetRegulationsQuery : IQuery<List<RegulationModel>>
    {
        public string TargetName { get; private set; }

        public GetRegulationsQuery(string targetName)
        {
            TargetName = targetName;
        }
    }
}