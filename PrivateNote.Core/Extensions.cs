using System;

namespace PrivateNote.Core
{
    public static class Extensions
    {
        public static string ToHashString(this Guid guid)
        {
            return guid.ToString().Replace("-", string.Empty).ToLower();
        }
    }
}