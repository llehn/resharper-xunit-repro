using System;

namespace Lol.Utils.Exceptions
{
    /// <summary>
    /// Database exception class
    /// </summary>
    [Serializable]
    public sealed class LolDataException : Exception
    {
        /// <summary>
        /// Creates a new instance of a KardexDataException
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Underlying Exception</param>
        public LolDataException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
