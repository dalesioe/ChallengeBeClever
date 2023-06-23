namespace ChallengeBeClever.Common.Model
{
    public interface IResult<out TValue> : IResult
    {
        new TValue Value { get; }
    }
}
