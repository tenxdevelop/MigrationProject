using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Repositories
{
    public class RegulationRepository : IRegulationRepository
    {
        //у нас в репозитории этом коль не путаю элементво 5 будет, на кой ляд асинхронность
        public List<RegulationModel> regulationModels;

        public RegulationRepository() { }

        public Task<IList<RegulationModel>> GetAllRegulations()
        {
            return Task.FromResult<IList<RegulationModel>>(regulationModels);
        }

        public Task<RegulationModel?> GetRegulationWithCountry(string country)
        {
            return Task.FromResult(regulationModels.FirstOrDefault(x => x.Country == country));
        }

        public Task UpdateRegulation(RegulationModel regulation)
        {
            var index = regulationModels.FindIndex(x => x.Country == regulation.Country);
            if (index != -1)
            {
                regulationModels[index] = regulation;
            }
            return Task.CompletedTask;
        }
    }
}
