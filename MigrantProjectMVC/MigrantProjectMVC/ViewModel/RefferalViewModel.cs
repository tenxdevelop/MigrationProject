namespace MigrantProjectMVC.ViewModel
{
    public class RefferalViewModel : SharedViewModel
    {
        public string RefferalText { get; private set; }
        public string ErrorMessage { get; private set; }

        public static RefferalViewModel Create(string refferalText, string errorMessage = "")
        {
            return new RefferalViewModel() { RefferalText = refferalText, ErrorMessage = errorMessage };
        }
    }
}