using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.Commands
{
    public class RegisterRegulationCommand : ICommand<bool>
    {
        public string TargetName { get; private set; }
        public string RegulationName { get; private set; }
        public int Term { get; private set; }
        public List<string> CountriesNames { get; private set; }
        public List<string> UseDocumentsNames { get; private set; }

        public RegisterRegulationCommand(string targetName, string regulationName, int term, List<string> countriesNames, List<string> useDocumentsNames)
        {
            TargetName = targetName;
            RegulationName = regulationName;
            Term = term;
            CountriesNames = countriesNames;
            UseDocumentsNames = useDocumentsNames;
        }
    }
}