namespace MigrantProjectMVC.Models
{
    [Serializable]
    public class ConditionModel
    {
        public string Instruction { get; set; }

        public void Update(string newInstruction)
        {
            Instruction = newInstruction;
        }
    }
}