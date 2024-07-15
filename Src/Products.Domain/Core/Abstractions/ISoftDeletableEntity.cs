namespace Products.Domain.Core.Abstractions
{
    internal class ISoftDeletableEntity
    {
        DateTime? DeletedOnUtc { get; }

        bool Deleted { get; }
    }
}
