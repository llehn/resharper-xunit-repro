using System;

namespace Lol.Utils.Exceptions
{
    /// <summary>
    /// Base class for all KSS exceptions. 
    /// </summary>
    [Serializable]
    public class LolException : Exception
    {
        /// <summary>
        /// Creates a new instance of a KardexException
        /// </summary>
        /// <param name="message">message</param>
        public LolException(string message)
            : base(message)
        { 
        }
    }
}
