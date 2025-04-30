﻿using EMS.Domain.Abstraction;
using EMS.Persistence.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace EMS.Persistence.Impelementations
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly EMSDBContext _context;

        public UnitOfWork(EMSDBContext context) => _context = context;

        public async Task<IDbContextTransaction> BeginTransactionAsync(
            CancellationToken cancellationToken = default
        ) => await _context.Database.BeginTransactionAsync(cancellationToken);

        public async ValueTask DisposeAsync() => await _context.DisposeAsync();

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            await _context.SaveChangesAsync(cancellationToken);
    }
}
