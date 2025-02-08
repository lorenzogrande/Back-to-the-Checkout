using System.Collections.Generic;
using Checkout.Src.Constants;
using Checkout.Src.Entities;
using Checkout.Src.Pricings;

namespace Checkout.Tests.Builders
{
    public class DefaultPricingStrategyBuilder
    {
        private readonly List<PricingRule> pricingRules = [];

        public DefaultPricingStrategyBuilder WithEveryPricingRule()
        {
            pricingRules.Add(PricingRules.RuleA);
            pricingRules.Add(PricingRules.RuleB);
            pricingRules.Add(PricingRules.RuleC);
            pricingRules.Add(PricingRules.RuleD);
            return this;
        }

        public DefaultPricingStrategyBuilder WithPricingRule(PricingRule rule)
        {
            pricingRules.Add(rule);
            return this;
        }

        public DefaultPricingStrategy Build()
        {
            return new DefaultPricingStrategy(pricingRules);
        }
    }
}
