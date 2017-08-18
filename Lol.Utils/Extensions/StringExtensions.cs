namespace Lol.Utils.Extensions
{
    /// <summary>
    /// Extensions for String
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Static version of IsNullOrEmpty
        /// </summary>
        /// <param name="s">string to check</param>
        /// <returns>true or false</returns>
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }
    }
}
