using System;
using System.Diagnostics.CodeAnalysis;

namespace Checkout.Src.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class EmptySkuException : ArgumentException
    {
        private static readonly string DefaultMessage = "SKU cannot be null or empty";
        public EmptySkuException()
            : base(DefaultMessage)
        {
        }
    }
}
