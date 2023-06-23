using ChallengeBeClever.Application.Interfaces;
using ChallengeBeClever.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace ChallengeBeClever.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<Users> GetUser(string username, string password)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
            return result;
        }
    }
}
