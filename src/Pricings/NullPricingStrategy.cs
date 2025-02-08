using Checkout.Src.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Checkout.Src.Pricings
{
    [ExcludeFromCodeCoverage]
    public class NullPricingStrategy : IPricingStrategy
    {
        public Price CalculateTotal(ScannedItems scannedItems)
        {
            return new Price(0);
        }
    }
}
