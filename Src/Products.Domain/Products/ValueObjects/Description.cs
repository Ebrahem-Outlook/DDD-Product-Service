using Products.Domain.Core.BaseType;
using Products.Domain.Core.BaseType.Result;
using Products.Domain.Core.Errors;

namespace Products.Domain.Products.ValueObjects;

public sealed class Description : ValueObject
{
    public const int MinLength = 10;
    public const int MaxLength = 2000;

    private Description(string value) => Value = value;
    
    public string Value { get; }

    public static Result<Description> Create(string description) =>
        Result.Create(description, DomainErrors.Description.NullOrEmpty)
            .Ensure(d => string.IsNullOrWhiteSpace(d), DomainErrors.Description.NullOrEmpty)
            .Ensure(d => d.Length > MaxLength, DomainErrors.Description.LongerThanAllowed)
            .Ensure(d => d.Length < MinLength, DomainErrors.Description.ShorterThanAllowed)
            .Map(d => new Description(d));
            
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
 