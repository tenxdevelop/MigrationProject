﻿using MigrantProjectMVC.Interfaces;
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
                            Country  = "Украина",
                        },
                        new RegulationModel()
                        {
                            Name = "Документ, подтверждающий постановку на миграционный учет по месту пребывания",
                            Rules ="Нужно сделать:Вам необходимо обратиться к лицу, у которого проживаете, " +
                                    "для того чтобы собственник помещения направил уведомление" +
                                    " в УМВД через портал государственных услуг о постановке на миграционный" +
                                    " учет иностранного гражданина по месту пребывания",
                            Term = 90,
                            Country  = "Белоруссь",
                        },
                         new RegulationModel()
                        {
                            Name = "Документ, подтверждающий постановку на миграционный учет по месту пребывания",
                            Rules ="Нужно сделать:Вам необходимо обратиться к лицу, у которого проживаете, " +
                                    "для того чтобы собственник помещения направил уведомление" +
                                    " в УМВД через портал государственных услуг о постановке на миграционный" +
                                    " учет иностранного гражданина по месту пребывания",
                            Term = 90,
                            Country  = "Высококвалифицированных специалистов и членов их семей (впервые)",
                        },
                         new RegulationModel()
                        {
                            Name = "Документ, подтверждающий постановку на миграционный учет по месту пребывания",
                            Rules ="Нужно сделать:Вам необходимо обратиться к лицу, у которого проживаете, " +
                                    "для того чтобы собственник помещения направил уведомление" +
                                    " в УМВД через портал государственных услуг о постановке на миграционный" +
                                    " учет иностранного гражданина по месту пребывания",
                            Term = 30,
                            Country = "Киргизия"
                        },
                          new RegulationModel()
                        {
                            Name = "Документ, подтверждающий постановку на миграционный учет по месту пребывания",
                            Rules ="Нужно сделать:Вам необходимо обратиться к лицу, у которого проживаете, " +
                                    "для того чтобы собственник помещения направил уведомление" +
                                    " в УМВД через портал государственных услуг о постановке на миграционный" +
                                    " учет иностранного гражданина по месту пребывания",
                            Term = 30,
                            Country = "Казахстан"
                        },
                           new RegulationModel()
                        {
                            Name = "Документ, подтверждающий постановку на миграционный учет по месту пребывания",
                            Rules ="Нужно сделать:Вам необходимо обратиться к лицу, у которого проживаете, " +
                                    "для того чтобы собственник помещения направил уведомление" +
                                    " в УМВД через портал государственных услуг о постановке на миграционный" +
                                    " учет иностранного гражданина по месту пребывания",
                            Term = 30,
                            Country = "Армения"
                        },
                            new RegulationModel()
                        {
                            Name = "Документ, подтверждающий постановку на миграционный учет по месту пребывания",
                            Rules ="Нужно сделать:Вам необходимо обратиться к лицу, у которого проживаете, " +
                                    "для того чтобы собственник помещения направил уведомление" +
                                    " в УМВД через портал государственных услуг о постановке на миграционный" +
                                    " учет иностранного гражданина по месту пребывания",
                            Term = 30,
                            Country = "Высококвалифицированных специалистов и членов их семей (повторно)"
                        },
                        new RegulationModel()
                        {
                            Name = "Документ, подтверждающий постановку на миграционный учет по месту пребывания",
                            Rules ="Нужно сделать:Вам необходимо обратиться к лицу, у которого проживаете, " +
                                    "для того чтобы собственник помещения направил уведомление" +
                                    " в УМВД через портал государственных услуг о постановке на миграционный" +
                                    " учет иностранного гражданина по месту пребывания",
                            Term = 15,
                            Country = "Таджикистан"
                        },
                        new RegulationModel()
                        {
                            Name = "Документ, подтверждающий постановку на миграционный учет по месту пребывания",
                            Rules ="Нужно сделать:Вам необходимо обратиться к лицу, у которого проживаете, " +
                                    "для того чтобы собственник помещения направил уведомление" +
                                    " в УМВД через портал государственных услуг о постановке на миграционный" +
                                    " учет иностранного гражданина по месту пребывания",
                            Term = 15,
                            Country = "Узбекистан"
                        },
                        new RegulationModel()
                        {
                            Name = "Документ, подтверждающий постановку на миграционный учет по месту пребывания",
                            Rules ="Нужно сделать:Вам необходимо обратиться к лицу, у которого проживаете, " +
                                    "для того чтобы собственник помещения направил уведомление" +
                                    " в УМВД через портал государственных услуг о постановке на миграционный" +
                                    " учет иностранного гражданина по месту пребывания",
                            Term = 7,
                           Country = "Иная"
                        },
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
            var regulation = Regulations.FirstOrDefault(x => x.Country == country);
            return Task.FromResult(regulation);
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