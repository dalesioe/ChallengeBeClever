// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace ChallengeBeClever.Common.Model
{
    public class NotAuthorizedError : Error
    {
        private const string ErrorCode = "AUTHORIZATION_ERROR";
        private const string ErrorMessage = "You are not authorized to perform this action";

        public NotAuthorizedError() : base(ErrorCode, ErrorMessage)
        {
        }

        public NotAuthorizedError(ErrorCatalogEntry catalogEntry) : base(catalogEntry)
        {
        }

        public NotAuthorizedError(string code, string message) : base(code, message)
        {
        }
    }
}
