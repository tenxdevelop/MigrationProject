namespace MigrantProjectMVC.ViewModel
{
    public class SharedViewModel
    {
        public bool IsHaveMigrantData { get; private set; }

        
        public static SharedViewModel Create(bool isHaveMigrantData)
        {
            return new SharedViewModel() { IsHaveMigrantData = isHaveMigrantData };
        }
    }
}