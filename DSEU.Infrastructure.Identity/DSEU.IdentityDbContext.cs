using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DSEU.Infrastructure.Identity
{
    public class DSEUIdentityDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DSEUIdentityDbContext(DbContextOptions<DSEUIdentityDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<UserPasswordHistory> UserPasswordHistory { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DSEUIdentityDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
