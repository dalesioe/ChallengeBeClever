namespace ChallengeBeClever.Application.UseCases.Auth
{
    public class UserRequest
    {
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
