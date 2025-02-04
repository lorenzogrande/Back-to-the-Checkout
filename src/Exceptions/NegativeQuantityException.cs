using System;

namespace Checkout.Src.Exceptions
{
    public class NegativeQuantityException : ArgumentException
    {
        private static readonly string DefaultMessage = "Quantity cannot be negative";
        public NegativeQuantityException()
            : base(DefaultMessage)
        {
        }

        public NegativeQuantityException(string paramName)
            : base(DefaultMessage, paramName)
        {
        }

        public NegativeQuantityException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
