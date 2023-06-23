namespace ChallengeBeClever.Common.Model
{
    public interface IResult
    {
        object? Value { get; }
        Error? Error { get; }
    }
}
