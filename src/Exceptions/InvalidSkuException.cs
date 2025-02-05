using System;
using System.Diagnostics.CodeAnalysis;

namespace Checkout.Src.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class InvalidSkuException : ArgumentException
    {
        private static readonly string DefaultMessage = "SKU must contain only single alphabetic characters";
        public InvalidSkuException()
            : base(DefaultMessage)
        {
        }
    }
}
