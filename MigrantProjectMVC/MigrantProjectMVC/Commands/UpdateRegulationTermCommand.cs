using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using System.Windows.Input;

namespace MigrantProjectMVC.Commands
{
    public class UpdateRegulationTermCommand : ICommand<bool>
    {
        public RegulationModel Regulation { get; set; }

        public int Term { get; set; }

    }
}
