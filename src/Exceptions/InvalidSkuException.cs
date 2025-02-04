using System;

namespace Checkout.Src.Exceptions
{
    public class InvalidSkuException : ArgumentException
    {
        private static readonly string DefaultMessage = "SKU must contain only single alphabetic characters";
        public InvalidSkuException()
            : base(DefaultMessage)
        {
        }

        public InvalidSkuException(string paramName)
            : base(DefaultMessage, paramName)
        {
        }

        public InvalidSkuException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
