namespace MigrantProjectMVC.ViewModel
{
    public class SharedViewModel
    {
        public bool IsHaveMigrantData { get; set; }

        
        public static SharedViewModel Create(bool isHaveMigrantData)
        {
            return new SharedViewModel() { IsHaveMigrantData = isHaveMigrantData };
        }
    }
}