using System;

namespace Bridge.Commons.Location.Exceptions
{
    /// <summary>
    ///     Exceções de DateTime
    /// </summary>
    public class DateTimeKindException : Exception
    {
        /// <summary>
        ///     Construtor
        /// </summary>
        public DateTimeKindException() : base("Wrong DateTimeKind value, must be UTC.")
        {
        }

        /// <summary>
        ///     Construtor
        /// </summary>
        /// <param name="message"></param>
        public DateTimeKindException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Construtor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public DateTimeKindException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}