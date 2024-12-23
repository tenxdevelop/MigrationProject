using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.CommandHandlers
{
    public class CreateDocumentCommandHandler : ICommandHandler<CreateDocumentCommand, bool>
    {
        private IDocumentRepository _documentRepository;

        public CreateDocumentCommandHandler(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public Task<bool> Handle(CreateDocumentCommand requist)
        {
            var document = new DocumentModel()
            {
                OwnerId = requist.OwnerId,
                Name = requist.Name,
                Content = requist.Content,
                CreationDate = requist.CreationDate,
                DocumentType = new DocumentTypeModel() { Name = requist.Name }
            };
            _documentRepository.AddDocument(document);
            return Task.FromResult(true);
        }
    }
}
