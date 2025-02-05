using System;
using System.Diagnostics.CodeAnalysis;

namespace Checkout.Src.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class NegativePriceException : ArgumentException
    {

        private static readonly string DefaultMessage = "Price cannot be negative";
        public NegativePriceException()
            : base(DefaultMessage)
        {
        }

    }
}
