// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace ChallengeBeClever.Common.Model
{
    public static class ExceptionExtensions
    {
        public static UnexpectedError<TException> AsFusapError<TException>(this TException exception)
            where TException : Exception
        {
            return (UnexpectedError<TException>)UnexpectedError.FromException(exception);
        }
    }
}
