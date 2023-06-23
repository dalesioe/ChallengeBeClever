﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace ChallengeBeClever.Common.Model
{
    public static class ErrorCatalogEntryExtensions
    {
        public static ErrorCatalogEntry Format(this ErrorCatalogEntry entry, object arg0)
        {
            return new ErrorCatalogEntry(entry.Code, string.Format(entry.Message, arg0));
        }

        public static ErrorCatalogEntry Format(this ErrorCatalogEntry entry, object arg0, object arg1)
        {
            return new ErrorCatalogEntry(entry.Code, string.Format(entry.Message, arg0, arg1));
        }

        public static ErrorCatalogEntry Format(this ErrorCatalogEntry entry, object arg0, object arg1, object arg2)
        {
            return new ErrorCatalogEntry(entry.Code, string.Format(entry.Message, arg0, arg1, arg2));
        }

        public static ErrorCatalogEntry Format(this ErrorCatalogEntry entry, params object[] args)
        {
            return new ErrorCatalogEntry(entry.Code, string.Format(entry.Message, args));
        }
    }
}
