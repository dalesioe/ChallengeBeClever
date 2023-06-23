// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace ChallengeBeClever.Common.Model
{
    public class BusinessRuleViolatedError : Error
    {
        private const string ErrorCode = "BUSINESS_RULE_VIOLATION";
        private const string ErrorMessage = "One or more business rules were violated";

        public IEnumerable<BusinessRuleViolation> Violations { get; }

        public BusinessRuleViolatedError(params BusinessRuleViolation[] violations) : base(ErrorCode, ErrorMessage)
        {
            Violations = violations;
        }

        public override string ToString()
        {
            var details = string.Join(", ", Violations.Select(x => x.ToString()));

            if (string.IsNullOrEmpty(details))
            {
                details = "no details";
            }

            return base.ToString() + " (" + details + ")";
        }
    }
}
