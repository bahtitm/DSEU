using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;

namespace DSEU.Application.Common.Interfaces
{
    public interface IReadOnlyApplicationDbContext
    {
        IQueryable<T> Query<T>() where T : class;
        IQueryable<T> FromSqlInterpolated<T>(FormattableString format) where T : class;
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
