using Products.Domain.Core.BaseType;

namespace Products.Domain.Products.ValueObjects;

public sealed class Name : ValueObject
{
    private const int MinLength = 5;
    private const int MaxLength = 50;

    private Name(string value) => Value = value;

    public string Value { get; }

    public static Name Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException();
        }

        if (value.Length > MaxLength || value.Length < MinLength)
        {
            throw new ArgumentException();
        }

        return new Name(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
