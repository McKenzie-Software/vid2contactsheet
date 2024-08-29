namespace vid2contactsheet.Helpers
{
    public static class StringExtensions
    {
        public static string? TruncateLongString(this string str, int maxLength)
        {
            return string.IsNullOrEmpty(str) ? str : str.Substring(0, Math.Min(str.Length, maxLength));
        }
    }
}
