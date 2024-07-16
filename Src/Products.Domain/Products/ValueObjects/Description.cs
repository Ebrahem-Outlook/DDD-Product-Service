using Products.Domain.Core.BaseType;
using Products.Domain.Core.BaseType.Result;
using Products.Domain.Core.Errors;
using System.Net.Http.Headers;

namespace Products.Domain.Products.ValueObjects;

public sealed class Description : ValueObject
{
    public const int MinLength = 50;
    public const int MaxLenght = 2000;

    private Description(string value) => Value = value;
    
    public string Value { get; }

    public static Result<Description> Create(string value) =>
        Result.Create(value, DomainErrors.Description.NullOrEmpty)
              .Ensure(d => string.IsNullOrEmpty());

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
