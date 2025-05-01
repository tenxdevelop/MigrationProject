namespace MigrantProjectMVC.Models
{
    [Serializable]
    public class TargetModel
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public ConditionModel Condition { get; set; }
    }
}