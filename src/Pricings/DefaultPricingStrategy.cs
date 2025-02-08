using System;
using System.Collections.Generic;
using Checkout.Src.Entities;
using Checkout.Src.Exceptions;
namespace Checkout.Src.Pricings;
public class DefaultPricingStrategy : IPricingStrategy
{
    private readonly Dictionary<Sku, PricingRule> pricingRules;

    public DefaultPricingStrategy(IEnumerable<PricingRule> rules)
    {
        pricingRules = [];

        foreach (var rule in rules)
        {
            if (pricingRules.ContainsKey(rule.Sku))
            {
                throw new DuplicatePricingRuleException(rule.Sku);
            }
            pricingRules[rule.Sku] = rule;
        }
    }

    public Price CalculateTotal(ScannedItems scannedItems)
    {
        decimal total = 0;

        foreach (var item in scannedItems.GetItems())
        {
            var sku = item.Key;
            var count = item.Value.Value;

            if (pricingRules.TryGetValue(sku, out var rule))
            {
                if (rule.DiscountThreshold.Value > 0)
                {
                    int discountedItems = count / rule.DiscountThreshold.Value;
                    int regularItems = count - discountedItems;

                    total += discountedItems * rule.DiscountedPrice.Value + regularItems * rule.RegularPrice.Value;
                }
                else
                {
                    total += count * rule.RegularPrice.Value;
                }
            }
            else
            {
                throw new MissingPricingRuleException(sku);
            }
        }

        return new Price(total);
    }
}
