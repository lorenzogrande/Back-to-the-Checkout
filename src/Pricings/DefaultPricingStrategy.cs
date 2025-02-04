using System.Collections.Generic;
using System.Linq;
using Checkout.Src.Entities;
using Checkout.Src.Exceptions;
namespace Checkout.Src.Pricings;
public class DefaultPricingStrategy : IPricingStrategy
{
    private readonly Dictionary<Sku, PricingRule> pricingRules;

    public DefaultPricingStrategy(IEnumerable<PricingRule> rules)
    {
        pricingRules = rules.ToDictionary(rule => rule.Sku);
    }

    public Price CalculateTotal(Dictionary<Sku, Quantity> scannedItems)
    {
        decimal total = 0;

        foreach (var item in scannedItems)
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
