using MigrantProjectMVC.Interfaces;
using System.Windows.Input;

namespace MigrantProjectMVC.Commands
{
    public class CreateDocumentCommand : ICommand<bool>
    {
        public Guid OwnerId  { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public CreateDocumentCommand(Guid ownerId, string name, string content, DateTime creationDate) 
        {
            OwnerId = ownerId;
            Name = name;
            Content = content;
            CreationDate = creationDate;
        }
    }
}
