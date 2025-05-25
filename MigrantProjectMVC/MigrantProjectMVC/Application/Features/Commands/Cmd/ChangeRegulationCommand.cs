using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.Commands
{

    public class ChangeRegulationCommand : ICommand<bool>
    {
        public string TargetName { get; private set; }
        public string RegulationName { get; private set; }
        
        public List<string>  CountryNames { get; private set; }
        public List<string> UseDocumentNames { get; private set; }
        
        public int Term { get; private set; }

        public ChangeRegulationCommand(string targetName, string regulationName, List<string> countryNames, List<string> useDocuments, int term)
        {
            TargetName = targetName;
            RegulationName = regulationName;
            CountryNames = countryNames;
            UseDocumentNames = useDocuments;
            Term = term;
        }
    }
}