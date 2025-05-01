namespace MigrantProjectMVC.ViewModel
{
    public class RegisterViewModel : SharedViewModel
    {
        public bool IsRegisterSuccess { get; private set; }
        public string ErrorMessage { get; private set; }

        public static RegisterViewModel Create(bool isRegisterSuccess, string errorMessage)
        {
            return new RegisterViewModel() { IsRegisterSuccess = isRegisterSuccess, ErrorMessage = errorMessage };
        }
    }
}