using System;

namespace Checkout.Src.Exceptions
{
    public class EmptySkuException : ArgumentException
    {
        private static readonly string DefaultMessage = "SKU cannot be null or empty";
        public EmptySkuException()
            : base(DefaultMessage)
        {
        }

        public EmptySkuException(string paramName)
            : base(DefaultMessage, paramName)
        {
        }

        public EmptySkuException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
