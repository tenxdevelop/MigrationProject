using MigrantProjectMVC.Interfaces.Services;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Application.Features.Services
{
    public class TargetService : ITargetService
    {
        private ITargetRepository _targetRepository;
        
        private ICountryRepository _countryRepository;
        private IDocumentRepository _documentRepository;

        public TargetService(ITargetRepository targetRepository)
        {
            _targetRepository = targetRepository;
            
        }

        public async Task<bool> RegisterTarget(string targetName)
        {
            var isHaveTarget = await _targetRepository.IsHaveTarget(targetName);

            if (isHaveTarget)
                return false;

            var result = await _targetRepository.RegisterTarget(targetName);
            return result;
        }

        public async Task<bool> DeleteTarget(string targetName)
        {
            var isHaveTarget = await _targetRepository.IsHaveTarget(targetName);

            if (!isHaveTarget)
                return false;

            var result = await _targetRepository.DeleteTarget(targetName);
            return result;
        }

        public async Task<bool> RegisterRegulation(string targetName, string regulationName, List<string> countryNames, List<string> useDocumentNames, int term)
        {
            var isHaveTarget = await _targetRepository.IsHaveTarget(targetName);

            if (!isHaveTarget)
                return false;

            var target = await _targetRepository.GetTarget(targetName, DateTime.Now);

            var countries = new List<CountryModel>();
            
            foreach (var countryName in countryNames)
            {
                var country = await _countryRepository.GetCountryByName(countryName);
                
                if(country is not null)
                    countries.Add(country);
            }
            
            var useDocuments = new List<Document>();
            
            foreach (var documentName in useDocumentNames)
            {
                var document = await _documentRepository.GetDocument(documentName);
                
                if(document is not null)
                    useDocuments.Add(document);
            }

            var newRegulation = new RegulationModel()
            {
                Name = regulationName,
                Term = term,
                Countries = countries,
                UseDocuments = useDocuments
            };
            
            var regulations = target.GetRegulations();
            regulations.Add(newRegulation);

            var result = await _targetRepository.SaveTarget(target);
            return result;
        }

        public async Task<bool> DeleteRegulation(string targetName, string regulationName)
        {
            var isHaveTarget = await _targetRepository.IsHaveTarget(targetName);

            if (!isHaveTarget)
                return false;
            
            var target = await _targetRepository.GetTarget(targetName, DateTime.Now);
            
            var regulations = target.GetRegulations();
            var regulationDelete = regulations.First(x => x.Name == regulationName);
            regulations.Remove(regulationDelete);
            
            var result = await _targetRepository.SaveTarget(target);
            return result;
        }

        public async Task<bool> ChangeCondition(string targetName, string newInstruction)
        {
            var target = await _targetRepository.GetTarget(targetName, DateTime.Now);
            
            target.Condition.Update(newInstruction);
            var result = await _targetRepository.SaveTarget(target);
            return result;
        }

        public async Task<bool> ChangeRegulation(string regulationName, string targetName, List<string> countryNames, List<string> useDocumentNames, int term)
        {
            var isHaveTarget = await _targetRepository.IsHaveTarget(targetName);

            if (!isHaveTarget)
                return false;
            
            var target = await _targetRepository.GetTarget(targetName, DateTime.Now);
            
            var countries = new List<CountryModel>();
            
            foreach (var countryName in countryNames)
            {
                var country = await _countryRepository.GetCountryByName(countryName);
                
                if(country is not null)
                    countries.Add(country);
            }
            
            var useDocuments = new List<Document>();
            
            foreach (var documentName in useDocumentNames)
            {
                var document = await _documentRepository.GetDocument(documentName);
                
                if(document is not null)
                    useDocuments.Add(document);
            }
            var regulations = target.GetRegulations();
            
            var regulation = regulations.First(x => x.Name == regulationName);
            
            regulation.Update(countries, useDocuments, term);
            
            var result = await _targetRepository.SaveTarget(target);
            return result;
        }
    }
}