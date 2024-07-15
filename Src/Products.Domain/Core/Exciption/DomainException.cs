using Products.Domain.Core.BaseType;

namespace Products.Domain.Core.Exciption;

public class DomainException : Exception
{
    public DomainException(Error error) : base(error.Message)
    {
        Error = error;
    }

    public Error Error { get; }
}
