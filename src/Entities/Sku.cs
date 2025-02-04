using System.Text.RegularExpressions;
using Checkout.Src.Exceptions;
namespace Checkout.Src.Entities;

public class Sku
{
    public string Value { get; }

    public Sku(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new EmptySkuException();

        if (!Regex.IsMatch(value, @"^[a-zA-Z]$"))
            throw new InvalidSkuException();

        Value = value;
    }

    public override bool Equals(object obj)
    {
        return obj is Sku sku && Value == sku.Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}
