using Checkout.Src.Entities;

namespace Checkout.Src.Constants
{
    public static class PricingRules
    {
        public static readonly PricingRule RuleA = new(new Sku("A"), new Price(50), new Price(30), new Quantity(3));
        public static readonly PricingRule RuleB = new(new Sku("B"), new Price(30), new Price(15), new Quantity(2));
        public static readonly PricingRule RuleC = new(new Sku("C"), new Price(20), new Price(0), new Quantity(0));
        public static readonly PricingRule RuleD = new(new Sku("D"), new Price(15), new Price(0), new Quantity(0));
    }
}
