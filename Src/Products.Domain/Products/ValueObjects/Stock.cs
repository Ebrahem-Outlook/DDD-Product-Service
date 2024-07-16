using Products.Domain.Core.BaseType;
using Products.Domain.Core.BaseType.Result;
using Products.Domain.Core.Errors;

namespace Products.Domain.Products.ValueObjects;

public sealed class Stock : ValueObject
{
    private Stock(int value) => Value = value;
    
    public int Value { get; }

    public static Result<Stock> Create(int stock) =>
        Result.Create(stock, DomainErrors.Stock.InValidCount)
            .Ensure(s => s < 0, DomainErrors.Stock.InValidCount)
            .Map(s => new Stock(s));

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
