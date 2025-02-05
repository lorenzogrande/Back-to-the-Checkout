using Checkout.Src.Entities;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Checkout.Src.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class MissingPricingRuleException : Exception
    {
        public MissingPricingRuleException(Sku sku)
            : base($"No pricing rule defined for SKU: {sku.Value}")
        {
        }
    }
}
