namespace MigrantProjectMVC.Models
{
    [Serializable]
    public class TargetModel
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public ConditionModel Condition { get; set; }
        
        public List<RegulationModel> Regulations { get; set; }


        public ConditionModel GetCondition()
        {
            return Condition;
        }

        public List<RegulationModel> GetRegulations()
        {
            return Regulations;
        }
    }
}