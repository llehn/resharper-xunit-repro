// This namespace sits in extra folder to prevent collision with FluentAssertions.
namespace Lol.Utils.Extensions.TimeSpan
{
    /// <summary>
    /// Timespan extensions
    /// </summary>
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// Returns a timespan "seconds"
        /// </summary>
        /// <param name="seconds">how many seconds</param>
        /// <returns>Timespan</returns>
        public static System.TimeSpan Seconds(this int seconds)
        {
            return System.TimeSpan.FromSeconds(seconds);
        }
    }
}
