namespace ChallengeBeClever.Application.Interfaces
{
    public interface IAuthService
    {
        public Task<string> Login(string username, string password);
    }
}
