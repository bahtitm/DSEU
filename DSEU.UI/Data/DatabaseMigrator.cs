using DSEU.Infrastructure.Identity;
using DSEU.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DSEU.UI.Data
{
    public class DatabaseMigrator
    {
        private readonly IdentityDbContext identityDbContext;
        private readonly AppDbContext appDbContext;

        public DatabaseMigrator(IdentityDbContext identityDbContext, AppDbContext appDbContext)
        {
            this.identityDbContext = identityDbContext;
            this.appDbContext = appDbContext;
        }

        public async Task MigrateAsync()
        {
            await identityDbContext.Database.MigrateAsync();
            await appDbContext.Database.MigrateAsync();
        }
    }
}
