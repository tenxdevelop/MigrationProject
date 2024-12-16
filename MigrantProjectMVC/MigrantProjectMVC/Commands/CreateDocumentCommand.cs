using MigrantProjectMVC.Interfaces;
using System.Windows.Input;

namespace MigrantProjectMVC.Commands
{
    public class CreateDocumentCommand : ICommand<bool>
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public CreateDocumentCommand(string name, string content, DateTime creationDate) 
        {
            Name = name;
            Content = content;
            CreationDate = creationDate;
        }
    }
}
