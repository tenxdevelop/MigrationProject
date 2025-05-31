namespace MigrantProjectMVC.Models
{
    public class TargetDTO
    {
        public string targetName { get; set; }
        public string instructionText { get; set; }
        public List<RegulationDTO> regulations { get; set; }
    }
}
