using Products.Domain.Core.BaseType;
using Products.Domain.Core.BaseType.Result;
using Products.Domain.Core.Errors;

namespace Products.Domain.Products.ValueObjects;

public sealed class Price : ValueObject
{
    private Price(decimal value) => Value = value;
    
    public decimal Value { get; }

    public static Result<Price> Create(decimal price) =>
        Result.Create(price, DomainErrors.Price.InValidPrice)
            .Ensure(p => p <= 0, DomainErrors.Price.InValidPrice)
            .Map(p => new Price(p));

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
