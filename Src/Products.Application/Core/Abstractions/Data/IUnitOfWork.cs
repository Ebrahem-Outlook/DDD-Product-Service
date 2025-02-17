﻿using Microsoft.EntityFrameworkCore.Storage;

namespace Products.Application.Core.Abstractions.Data;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken);
}
