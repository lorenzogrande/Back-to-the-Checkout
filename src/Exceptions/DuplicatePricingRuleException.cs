using System;
using Checkout.Src.Entities;

namespace Checkout.Src.Exceptions
{
    public class DuplicatePricingRuleException : Exception
    {
        public DuplicatePricingRuleException(Sku sku)
            : base($"Duplicate pricing rule found for SKU: {sku.Value}")
        {
        }
    }
}
