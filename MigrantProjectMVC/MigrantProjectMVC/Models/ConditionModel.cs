namespace MigrantProjectMVC.Models
{
    [Serializable]
    public class ConditionModel
    {
        public string Instruction { get; set; }

        public ConditionModel()
        {
            
        }
        
        public ConditionModel(string instruction)
        {
            Instruction = instruction;
        }
        
        public void Update(string newInstruction)
        {
            Instruction = newInstruction;
        }

        public string GetInstruction()
        {
            return Instruction;
        }
    }
}