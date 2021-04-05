using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Exceptions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities;

namespace DSEU.Application.Common.Extensions
{
    public static class DbContextExtensions
    {
        /// <summary>
        /// Найти запись по Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbContext"></param>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="ignoreQueryFilter"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"/>
        public static async Task<T> FindByIdAsync<T>(this IApplicationDbContext dbContext, int id, CancellationToken cancellationToken = default)
            where T : BaseEntity
        {
            var items = dbContext.Set<T>();

            var item = await items.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            if (item == null)
            {
                throw new NotFoundException(typeof(T).Name, id);
            }
            return item;
        }
    }
}