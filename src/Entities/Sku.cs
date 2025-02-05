using System.Text.RegularExpressions;
using Checkout.Src.Exceptions;
namespace Checkout.Src.Entities;

public partial class Sku
{
    public string Value { get; }
    private static readonly Regex allowedSku = generateValidSkuRegex();

    public Sku(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new EmptySkuException();

        if (!allowedSku.IsMatch(value))
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

    [GeneratedRegex(@"^[a-zA-Z]$", RegexOptions.Compiled)]
    private static partial Regex generateValidSkuRegex();
}
