namespace MigrantProjectMVC.Interfaces
{
    public interface ITokenProvider
    {
        public string GenerateToken(string token);
    }
}