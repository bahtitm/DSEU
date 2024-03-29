using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<T> Set<T>() where T : class;
        Task AddAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task InvokeTransactionAsync(Func<Task> action, CancellationToken cancellationToken = default);
        Task<T> InvokeTransactionAsync<T>(Func<Task<T>> action, CancellationToken cancellationToken = default);
    }
}
