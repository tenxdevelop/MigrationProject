namespace MigrantProjectMVC.ViewModel
{
    public class MigrantViewModel : SharedViewModel
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Patronymic { get; private set; }
        public DateTime EnteringDate { get; private set; }

        public string CountryName { get; private set; }
        public List<string> DocumentNames { get; private set; }
        
    }
}