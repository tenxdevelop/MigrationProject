namespace MigrantProjectMVC.Models
{
    [Serializable]
    public class ConditionModel
    {
        public string Instruction { get; set; }
        public List<RegulationModel> Regulations { get; set; }
    }
}