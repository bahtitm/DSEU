using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Exceptions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Common.Extensions
{
    public static class ReadOnlyDbContextExtensions
    {
        /// <summary>
        /// Найти запись по Id
        /// </summary>
        /// <remarks>
        /// Ищет запись с отключенным Трекингом. AsNoTracking()
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbContext"></param>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="ignoreQueryFilter"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"/>
        public static async Task<T> FindByIdAsync<T>(this IReadOnlyApplicationDbContext dbContext, int id, CancellationToken cancellationToken = default)
            where T : BaseEntity
        {
            var item = await dbContext.Query<T>().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            if (item == null)
            {
                throw new NotFoundException(typeof(T).Name, id);
            }
            return item;
        }

        /// <summary>
        /// Статус записи активен
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbContext"></param>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<bool> IsActiveAsync<TEntity>(this IReadOnlyApplicationDbContext dbContext, int id, CancellationToken cancellationToken = default)
            where TEntity : DatabookEntry
        {
            return await dbContext.Query<TEntity>().AnyAsync(p => p.Id == id && p.Status == Status.Active);
        }

        /// <summary>
        /// Проверить корректность на каскадность
        /// </summary>
        /// <typeparam name="TDependency"></typeparam>
        /// <param name="dbContext"></param>
        /// <param name="ownerId"></param>
        /// <param name="dependencyPropertyValue"></param>
        /// <param name="dependencyPropertyName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<bool> IsCascadeBetween<TDependency>(this IReadOnlyApplicationDbContext dbContext, int ownerId, int dependencyPropertyValue, string dependencyPropertyName, CancellationToken cancellationToken = default)
            where TDependency : BaseEntity
        {
            var item = await dbContext.FindByIdAsync<TDependency>(ownerId, cancellationToken);
            var propertyValue = item.GetType().GetProperty(dependencyPropertyName).GetValue(item);
            if (propertyValue != null)
            {
                if ((int)propertyValue == dependencyPropertyValue)
                    return true;
            }
            return false;
        }
    }

}

