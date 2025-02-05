using System;
using System.Diagnostics.CodeAnalysis;

namespace Checkout.Src.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class NegativeQuantityException : ArgumentException
    {
        private static readonly string DefaultMessage = "Quantity cannot be negative";
        public NegativeQuantityException()
            : base(DefaultMessage)
        {
        }

    }
}
