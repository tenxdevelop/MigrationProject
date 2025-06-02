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

        public TargetService(ITargetRepository targetRepository, ICountryRepository countryRepository, IDocumentRepository documentRepository)
        {
            _targetRepository = targetRepository;
            _countryRepository = countryRepository;
            _documentRepository = documentRepository;
        }

        public async Task<bool> RegisterTarget(string targetName, string instruction, List<RegulationDTO> regulationDtos)
        {
            var isHaveTarget = await _targetRepository.IsHaveTarget(targetName);

            if (isHaveTarget)
                return false;

            var regulations = new List<RegulationModel>();

            foreach (var regulationDto in regulationDtos)
            {
                var documents = new List<Document>();
                foreach (var documentName in regulationDto.documents)
                {
                    var document = await _documentRepository.GetDocument(documentName);
                    documents.Add(document);
                }
                
                var countries = new List<CountryModel>();
                foreach (var countryName in regulationDto.countries)
                {
                    var country = await _countryRepository.GetCountryByName(countryName);
                    countries.Add(country);
                }

                var regulation = new RegulationModel()
                {
                    Name = regulationDto.name,
                    Countries = countries,
                    UseDocuments = documents,
                    Term = int.Parse(regulationDto.term)
                };
                
                regulations.Add(regulation);
            }
            
            var result = await _targetRepository.RegisterTarget(targetName, instruction, regulations);
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

            var result = await _targetRepository.Save();
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
            
            var result = await _targetRepository.Save();
            return result;
        }

        public async Task<bool> ChangeCondition(string targetName, string newInstruction)
        {
            var target = await _targetRepository.GetTarget(targetName, DateTime.Now);
            
            target.Condition.Update(newInstruction);
            var result = await _targetRepository.Save();
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
            
            var result = await _targetRepository.Save();
            return result;
        }
    }
}