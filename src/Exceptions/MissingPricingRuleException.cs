using Checkout.Src.Entities;
using System;

namespace Checkout.Src.Exceptions
{
    public class MissingPricingRuleException : Exception
    {
        public MissingPricingRuleException(Sku sku)
            : base($"No pricing rule defined for SKU: {sku.Value}")
        {
        }
    }
}
