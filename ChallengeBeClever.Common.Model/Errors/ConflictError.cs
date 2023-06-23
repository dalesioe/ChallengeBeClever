// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.


namespace ChallengeBeClever.Common.Model
{
    public class ConflictError : Error
    {
        public ConflictError(ErrorCatalogEntry catalogEntry) : base(catalogEntry)
        {
        }

        public ConflictError(string code, string message) : base(code, message)
        {
        }
    }
}
