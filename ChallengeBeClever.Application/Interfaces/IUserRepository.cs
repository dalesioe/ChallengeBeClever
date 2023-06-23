using ChallengeBeClever.Domain.Entities.Auth;

namespace ChallengeBeClever.Application.Interfaces
{
    public interface IUserRepository
    {
        public Task<Users> GetUser(string username, string password);
    }
}
