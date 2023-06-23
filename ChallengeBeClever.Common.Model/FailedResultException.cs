using System.Runtime.Serialization;

namespace ChallengeBeClever.Common.Model
{
    [Serializable]
    public class FailedResultException : Exception
    {
        public Error Error { get; }

        public FailedResultException(Error error) : base($"Result was not successful. {error.Code}: '{error.Message}'")
        {
            Error = error;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected FailedResultException(SerializationInfo info, StreamingContext context) : base(info, context)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }
    }
}
