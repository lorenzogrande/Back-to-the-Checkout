using System.Collections.Generic;
namespace Checkout.Src.Entities;

public class ScannedItems
{
    private readonly Dictionary<Sku, Quantity> items = [];

    public void Add(Sku sku)
    {
        if (items.TryGetValue(sku, out Quantity? value))
        {
            items[sku] = new Quantity(value!.Value + 1);
        }
        else
        {
            items[sku] = new Quantity(1);
        }
    }

    public Dictionary<Sku, Quantity> GetItems()
    {
        return new Dictionary<Sku, Quantity>(items);
    }
}
