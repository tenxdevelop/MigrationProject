using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces
{
    public interface IRegulationRepository
    {
        public Task<IList<RegulationModel>> GetAllRegulations();
        public Task UpdateRegulation(RegulationModel regulation);
        public Task<RegulationModel?> GetRegulationWithCountry(string country);

    }
}
