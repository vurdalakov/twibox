namespace Vurdalakov
{
    using System;

    public static class StringExtensions
    {
        private const StringComparison StringComparisonIgnoreCase = StringComparison.OrdinalIgnoreCase;

        public static Boolean ContainsNoCase(this String value, String other)
        {
            return value.IndexOf(other, StringComparisonIgnoreCase) >= 0;
        }

        public static Boolean EqualsNoCase(this String value, String other)
        {
            return value.Equals(other, StringComparisonIgnoreCase);
        }

        public static Boolean StartsWithNoCase(this String value, String other)
        {
            return value.StartsWith(other, StringComparisonIgnoreCase);
        }

        public static Boolean EndsWithNoCase(this String value, String other)
        {
            return value.EndsWith(other, StringComparisonIgnoreCase);
        }
    }
}
