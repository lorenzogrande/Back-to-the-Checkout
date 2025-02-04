using System;

namespace Checkout.Src.Exceptions
{
    public class NegativePriceException : ArgumentException
    {

        private static readonly string DefaultMessage = "Price cannot be negative";
        public NegativePriceException()
            : base(DefaultMessage)
        {
        }

        public NegativePriceException(string paramName)
            : base(DefaultMessage, paramName)
        {
        }

        public NegativePriceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
