using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.QueryHandlers
{
    public class GetMigrantByIdQueryHandler : IQueryHandler<GetMigrantByIdQuery, MigrantModel>
    {
        private readonly IMigrantRepository _migrantRepository;
        public GetMigrantByIdQueryHandler(IMigrantRepository repository)
        {
            _migrantRepository = repository;
        }

        public Task<MigrantModel> Handle(GetMigrantByIdQuery query)
        {
            return _migrantRepository.GetMigrantById(query.Id);
        }
    }
}
