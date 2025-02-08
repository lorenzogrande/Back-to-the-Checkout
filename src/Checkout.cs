using Checkout.Src.Entities;
using Checkout.Src.Pricings;
using System;

namespace Checkout;

public class Checkout
{
    private readonly ScannedItems scannedItems = new ();
    private readonly IPricingStrategy pricingStrategy;

    public Checkout(IPricingStrategy pricingStrategy)
    {
        this.pricingStrategy = pricingStrategy ?? throw new ArgumentNullException(nameof(pricingStrategy));
    }

    public void ScanItem(Sku sku)
    {
        scannedItems.Add(sku);
    }

    public Price CalculateTotal()
    {
        return pricingStrategy.CalculateTotal(scannedItems);
    }
}
