using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Queries
{
    public class GetMigrantByIdQuery : IQuery<MigrantModel>
    {
        public Guid Id { get; set; }

        public GetMigrantByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
