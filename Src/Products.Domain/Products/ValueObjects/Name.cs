using Products.Domain.Core.BaseType;
using Products.Domain.Core.BaseType.Result;
using Products.Domain.Core.Errors;

namespace Products.Domain.Products.ValueObjects;

public sealed class Name : ValueObject
{
    public const int MinLength = 5;
    public const int MaxLength = 50;

    private Name(string value) => Value = value;

    public string Value { get; }

    public static Result<Name> Create(string name) =>
        Result.Create(name, DomainErrors.Name.NullOrEmpty)
            .Ensure(n => string.IsNullOrWhiteSpace(n), DomainErrors.Name.NullOrEmpty)
            .Ensure(n => n.Length <= MaxLength, DomainErrors.Name.LongerThanAllowed)
            .Ensure(n => n.Length >= MinLength, DomainErrors.Name.ShorterThanAllowed)
            .Map(n => new Name(n));

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
