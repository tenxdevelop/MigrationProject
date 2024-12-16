using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using System.Text.Json;

namespace MigrantProjectMVC.Repositories
{
    public class RegulationRepository : IRegulationRepository
    {
        public List<RegulationModel> Regulations;
        string _filePath = "jsons/regulations.json";
        public RegulationRepository() 
        {

            var fs = new FileStream(_filePath, FileMode.Open);
            try
            {
                Regulations = JsonSerializer.Deserialize<List<RegulationModel>>(fs);
                fs.Dispose();
            }
            catch (Exception ex)
            {
                Regulations = new List<RegulationModel>()
                    {
                        new RegulationModel()
                        {
                            Name = "Документ, подтверждающий постановку на миграционный учет по месту пребывания",
                            Rules ="Нужно сделать:Вам необходимо обратиться к лицу, у которого проживаете, " +
                                    "для того чтобы собственник помещения направил уведомление" +
                                    " в УМВД через портал государственных услуг о постановке на миграционный" +
                                    " учет иностранного гражданина по месту пребывания",
                            Term = 90,
                            Country  = "Для граждан Белоруссии, Украины, высококвалифицированных специалистов и членов их семей (не зависимо от страны исхода)",
                        },
                         new RegulationModel()
                        {
                            Name = "Документ, подтверждающий постановку на миграционный учет по месту пребывания",
                            Rules ="Нужно сделать:Вам необходимо обратиться к лицу, у которого проживаете, " +
                                    "для того чтобы собственник помещения направил уведомление" +
                                    " в УМВД через портал государственных услуг о постановке на миграционный" +
                                    " учет иностранного гражданина по месту пребывания",
                            Term = 30,
                            Country = "Для граждан Киргизии, Казахстана, Армении, высококвалифицированных специалистов и членов их семей (если ранее уже состояли на миграционном учете в РФ, при смене места регистрации)"
                        },
                        new RegulationModel()
                        {
                            Name = "Документ, подтверждающий постановку на миграционный учет по месту пребывания",
                            Rules ="Нужно сделать:Вам необходимо обратиться к лицу, у которого проживаете, " +
                                    "для того чтобы собственник помещения направил уведомление" +
                                    " в УМВД через портал государственных услуг о постановке на миграционный" +
                                    " учет иностранного гражданина по месту пребывания",
                            Term = 15,
                            Country = "Для граждан Таджикистана и Узбекистана"
                        },
                        new RegulationModel()
                        {
                            Name = "Документ, подтверждающий постановку на миграционный учет по месту пребывания",
                            Rules ="Нужно сделать:Вам необходимо обратиться к лицу, у которого проживаете, " +
                                    "для того чтобы собственник помещения направил уведомление" +
                                    " в УМВД через портал государственных услуг о постановке на миграционный" +
                                    " учет иностранного гражданина по месту пребывания",
                            Term = 7,
                           Country = "Для всех остальных иностранных граждан"
                        },
                        new RegulationModel()
                        {
                            Name = "Документ, подтверждающий постановку на миграционный учет по месту пребывания",
                            Rules ="Нужно сделать:Вам необходимо обратиться к лицу, у которого проживаете, " +
                                    "для того чтобы собственник помещения направил уведомление" +
                                    " в УМВД через портал государственных услуг о постановке на миграционный" +
                                    " учет иностранного гражданина по месту пребывания",
                            Term = 30,
                            Country = "Для участников государственной программы переселения соотечественников"
                        }
                    };
                fs.Dispose();
                SaveContext();
            }
        }

        public Task<IList<RegulationModel>> GetAllRegulations()
        {
            return Task.FromResult<IList<RegulationModel>>(Regulations);
        }

        public Task<RegulationModel?> GetRegulationWithCountry(string country)
        {
            return Task.FromResult(Regulations.FirstOrDefault(x => x.Country == country));
        }


        public Task UpdateRegulation(RegulationModel regulation) // переписать или этот метод или все остальные по его подобию
        {
            var index = Regulations.FindIndex(x => x.Country == regulation.Country);
            if (index != -1)
            {
                Regulations[index] = regulation;
            }
            SaveContext();
            return Task.CompletedTask;

        }

        public Task SaveContext()
        {
            var data = JsonSerializer.Serialize(Regulations);
            File.WriteAllText(_filePath, data);
            return Task.CompletedTask;
        }
    }
}
