using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Queries;
using MigrantProjectMVC.Repositories;

namespace MigrantProjectMVC.QueryHandlers
{
    public class GetAllDocsTypesQueryHandler : IQueryHandler<GetAllDocsTypesQuery, Dictionary<DocumentType, string>>
    {
        private IDocumentRepository _documentRepository;

        public GetAllDocsTypesQueryHandler(IDocumentRepository documentRepository) 
        {
            _documentRepository = documentRepository;
        }

        public async Task<Dictionary<DocumentType, string>> Handle(GetAllDocsTypesQuery query)
        {
            return await _documentRepository.GetAllDocumentTypes();
        }
    }
}
