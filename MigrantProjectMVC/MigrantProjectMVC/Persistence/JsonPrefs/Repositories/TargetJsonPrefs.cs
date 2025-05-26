using MigrantProjectMVC.Models.JsonPrefs.Base;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Repositories
{

    public class TargetJsonPrefs : JsonPrefs<List<TargetModel>>, ITargetRepository
    {
        private const string FILE_PATH = "jsons/target.json";

        private List<TargetModel> _targets;
        
        public TargetJsonPrefs() : base(FILE_PATH)
        {
            var regulations = new List<RegulationModel>();

           
                //for test
                var countries1 = new List<CountryModel>()
                {
                    new CountryModel() { Name="Киргизия"},
                    new CountryModel() { Name="Казахстан"},
                    new CountryModel() { Name="Армения"}
                
                };

                var useDocument1 = new List<Document>()
                {
                    new Document() { Name="HighlyQualifiedDocument"},
                    new Document() { Name="ConsistOfMigrationProgramDocument"}
                };
            
                var regulation1 = new RegulationModel() { Term=30, Name = "regulation1", Countries = countries1, UseDocuments = useDocument1 };
                regulations.Add(regulation1);
            
                var countries2 = new List<CountryModel>()
                {
                    new CountryModel() { Name="Белорусь"},
                    new CountryModel() { Name="Украина"}
                };

                var useDocuments2 = new List<Document>();
            
                var regulation2 = new RegulationModel() { Term = 90, Name = "regulation2", Countries = countries2, UseDocuments = useDocuments2 };
                regulations.Add(regulation2);
            
                var countries3 = new List<CountryModel>();
            
                var useDocuments3 = new List<Document>()
                {
                    new Document() { Name="HighlyQualifiedDocument"}
                };
            
                var regulation3 = new RegulationModel() { Term=90, Name = "regulation3", Countries = countries3, UseDocuments = useDocuments3 };
                regulations.Add(regulation3);
            
                var countries4 = new List<CountryModel>()
                {
                    new CountryModel() { Name="Таджикистан"},
                    new CountryModel() { Name="Узбекистан"}
                };
            
                var useDocuments4 = new List<Document>();
            
                var regulation4 = new RegulationModel() { Term=15, Name ="regulation4", Countries = countries4, UseDocuments = useDocuments4 };
                regulations.Add(regulation4);
            
                var countires5 = new List<CountryModel>()
                {
                    new CountryModel() { Name = "Другая страна" }
                };

                var useDocuments5 = new List<Document>();
            
                var regulation5 = new RegulationModel() {Term=7, Name="regulation5", Countries = countires5, UseDocuments = useDocuments5};
                regulations.Add(regulation5);
            
                var countires6 = new List<CountryModel>();

                var useDocuments6 = new List<Document>()
                {
                    new Document() { Name="ResettlementDocument"}
                };
            
                var regulation6 = new RegulationModel() {Term=30, Name="regulation6", Countries = countires6, UseDocuments = useDocuments6};
                regulations.Add(regulation6);
            
                var condition = new ConditionModel()
                {
                    Instruction = "вам необходимо обратиться к владельцу жил площади, чтобы он написал заявление на постановку миграционного учета на сайте гос услуг"
                };

                var target = new TargetModel()
                {
                    Name = "Постановка на миграционный учёт",
                    Date = DateTime.Today,
                    Condition = condition,
                    Regulations = regulations
                };
            
                _targets = new List<TargetModel>() { target };
                //SaveToJson(_targets);
 

            _targets = LoadFromJson();
        }
        public Task<TargetModel> GetTarget(string targetName, DateTime date)
        {

            var correctTargets = _targets.Where(target => target.Name.Equals(targetName));
            
            var actualTarget = correctTargets.MinBy(target => Convert.ToInt32((date - target.Date).TotalDays));
            
            return Task.FromResult(actualTarget);
        }
        public Task<List<TargetModel>> GetTargets()
        {
            return Task.FromResult(_targets);
        }

        public Task<bool> Save()
        {
            var result = SaveToJson(_targets);
            return Task.FromResult(result);
        }

        public Task<bool> IsHaveTarget(string targetName)
        {
            var target = _targets.Where(target => target.Name.Equals(targetName)).FirstOrDefault();
            return Task.FromResult(target is not null);
        }

        public Task<bool> RegisterTarget(string targetName)
        {
            var target = new TargetModel()
            {
                Name = targetName,
                Date = DateTime.Now,
                Condition = new ConditionModel(),
                Regulations = new List<RegulationModel>()
            };
            _targets.Add(target);
            var result = SaveToJson(_targets);
            return Task.FromResult(result);
        }

        public Task<bool> DeleteTarget(string targetName)
        {
            var target = _targets.Where(target => target.Name.Equals(targetName)).FirstOrDefault();
            
            _targets.Remove(target);
            var result = SaveToJson(_targets);
            return Task.FromResult(result);
        }
    }
}