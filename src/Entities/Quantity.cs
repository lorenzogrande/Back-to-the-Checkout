using Checkout.Src.Exceptions;

namespace Checkout.Src.Entities;

public class Quantity
{
    public int Value { get; }

    public Quantity(int value)
    {
        if (value < 0)
            throw new NegativeQuantityException();

        Value = value;
    }

    public override bool Equals(object obj)
    {
        return obj is Quantity quantity && Value == quantity.Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}
