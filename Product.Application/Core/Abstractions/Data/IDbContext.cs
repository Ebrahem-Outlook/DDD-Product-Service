using Microsoft.EntityFrameworkCore;
using Product.Domain.Core.BaseType;

namespace Product.Application.Core.Abstractions.Data;

public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : Entity;
}
