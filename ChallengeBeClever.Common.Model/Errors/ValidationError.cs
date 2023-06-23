// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace ChallengeBeClever.Common.Model
{
    public class ValidationError : Error
    {
        private const string ErrorCode = "VALIDATION_ERROR";
        private const string ErrorMessage = "One or more values were invalid";

        public IEnumerable<ValidationErrorDetail> Details { get; }

        public ValidationError(params ValidationErrorDetail[] details) : base(ErrorCode, ErrorMessage)
        {
            Details = details;
        }

        public override string ToString()
        {
            var details = string.Join(", ", Details.Select(x => x.ToString()));

            if (string.IsNullOrEmpty(details))
            {
                details = "no details";
            }

            return base.ToString() + " (" + details + ")";
        }
    }
}
