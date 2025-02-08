using System.Collections.Generic;
using System.Linq;
using Checkout.Src.Entities;
using Checkout.Src.Pricings;

namespace Checkout.Tests.Builders
{
    public class CheckoutBuilder
    {
        private readonly List<Sku> _scannedItems = new();
        private IPricingStrategy _pricingStrategy = new DefaultPricingStrategy(Enumerable.Empty<PricingRule>());

        public CheckoutBuilder WithScannedItem(Sku sku)
        {
            _scannedItems.Add(sku);
            return this;
        }

        public CheckoutBuilder WithDefaultPricingStrategy(IEnumerable<PricingRule> rules)
        {
            _pricingStrategy = new DefaultPricingStrategy(rules);
            return this;
        }

        public Checkout Build()
        {
            var pricingStrategy = _pricingStrategy;
            var checkout = new Checkout(pricingStrategy);
            foreach (var sku in _scannedItems)
            {
                checkout.ScanItem(sku);
            }
            return checkout;
        }
    }
}