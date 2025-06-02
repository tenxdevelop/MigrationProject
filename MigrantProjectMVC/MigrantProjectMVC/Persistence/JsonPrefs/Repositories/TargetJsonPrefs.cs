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

        public Task<bool> RegisterTarget(string targetName, string instruction, List<RegulationModel> regulations)
        {
            var target = new TargetModel(targetName, instruction, regulations);
            
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