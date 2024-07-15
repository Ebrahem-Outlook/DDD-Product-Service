using Products.Domain.Core.BaseType;

namespace Products.Domain.Products.ValueObjects;

public sealed class Price : ValueObject
{
    private Price(decimal value) => Value = value;
    
    public decimal Value { get; }

    public static Price Create(decimal value)
    {
        if (value <= 0)
        {
            throw new ArgumentException();
        }

        return new Price(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
