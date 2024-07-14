using Microsoft.EntityFrameworkCore;
using Products.Domain.Core.BaseType;

namespace Products.Application.Core.Abstractions.Data;

public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : Entity;
}
