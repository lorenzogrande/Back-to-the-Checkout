using System.Collections.Generic;
using Checkout.Src.Entities;
namespace Checkout.Src.Pricings;
public interface IPricingStrategy
{
    Price CalculateTotal(ScannedItems scannedItems);
}
