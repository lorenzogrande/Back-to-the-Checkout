using System.Collections.Generic;
using Checkout.Src.Constants;
using Checkout.Src.Entities;
using Checkout.Src.Pricings;

namespace Checkout.Tests
{
    public class CheckoutBuilder
    {
        private readonly List<PricingRule> _pricingRules = new();
        private readonly List<Sku> _scannedItems = new();

        public CheckoutBuilder WithPricingRule(PricingRule pricingRule)
        {
            _pricingRules.Add(pricingRule);
            return this;
        }

        public CheckoutBuilder WithEveryPricingRules()
        {
            this.WithPricingRule(PricingRules.RuleA);
            this.WithPricingRule(PricingRules.RuleB);
            this.WithPricingRule(PricingRules.RuleC);
            this.WithPricingRule(PricingRules.RuleD);
            return this;
        }

        public CheckoutBuilder WithScannedItem(Sku sku)
        {
            _scannedItems.Add(sku);
            return this;
        }

        public Checkout Build()
        {
            var pricingStrategy = new DefaultPricingStrategy(_pricingRules);
            var checkout = new Checkout(pricingStrategy);
            foreach (var sku in _scannedItems)
            {
                checkout.ScanItem(sku);
            }
            return checkout;
        }
    }
}