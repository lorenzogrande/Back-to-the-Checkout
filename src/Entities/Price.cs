using Checkout.Src.Exceptions;

namespace Checkout.Src.Entities;

public class Price
{
    public decimal Value { get; }

    public Price(decimal value)
    {
        if (value < 0)
            throw new NegativePriceException();

        Value = value;
    }

    public override bool Equals(object obj)
    {
        return obj is Price price && Value == price.Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}
