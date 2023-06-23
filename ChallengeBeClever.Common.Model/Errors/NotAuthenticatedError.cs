// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace ChallengeBeClever.Common.Model
{
    public class NotAuthenticatedError : Error
    {
        private const string ErrorCode = "AUTHENTICATION_ERROR";
        private const string ErrorMessage = "You are not authenticated.";

        public NotAuthenticatedError() : base(ErrorCode, ErrorMessage)
        {
        }

        public NotAuthenticatedError(ErrorCatalogEntry catalogEntry) : base(catalogEntry)
        {
        }

        public NotAuthenticatedError(string code, string message) : base(code, message)
        {
        }
    }
}
