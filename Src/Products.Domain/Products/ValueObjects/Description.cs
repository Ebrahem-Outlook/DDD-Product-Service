using Products.Domain.Core.BaseType;
using System.Net.Http.Headers;

namespace Products.Domain.Products.ValueObjects;

public sealed class Description : ValueObject
{
    public const int MinLength = 50;
    public const int MaxLenght = 2000;

    private Description(string value) => Value = value;
    
    public string Value { get; }

    public static Description Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException();
        }

        if (value.Length > MaxLenght || value.Length < MinLength)
        {
            throw new ArgumentException();
        }

        return new Description(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
