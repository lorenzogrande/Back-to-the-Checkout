namespace Checkout.Src.Entities;

public class PricingRule
{
    public Sku Sku { get; }
    public Price RegularPrice { get; }
    public Price DiscountedPrice { get; }
    public Quantity DiscountThreshold { get; }

    public PricingRule(Sku sku, Price regularPrice, Price discountedPrice, Quantity discountThreshold)
    {
        Sku = sku;
        RegularPrice = regularPrice;
        DiscountedPrice = discountedPrice;
        DiscountThreshold = discountThreshold;
    }
}
