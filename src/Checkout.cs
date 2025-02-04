using Checkout.Src.Entities;
using Checkout.Src.Pricings;

namespace Checkout;

public class Checkout
{
    private readonly ScannedItems scannedItems = new ScannedItems();
    private readonly IPricingStrategy pricingStrategy;

    public Checkout(IPricingStrategy pricingStrategy)
    {
        this.pricingStrategy = pricingStrategy;
    }

    public void ScanItem(Sku sku)
    {
        scannedItems.Add(sku);
    }

    public Price CalculateTotal()
    {
        return pricingStrategy.CalculateTotal(scannedItems.GetItems());
    }
}
