using Products.Domain.Core.BaseType;

namespace Products.Domain.Products.ValueObjects;

public sealed class Stock : ValueObject
{
    private Stock(int value) => Value = value;
    
    public int Value { get; }

    public static Stock Create(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException();
        }

        return new Stock(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
