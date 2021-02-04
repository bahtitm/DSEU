using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DSEU.Infrastructure.DataProtection
{
    public class DSEUDataProtectionKeysDbContext : DbContext, IDataProtectionKeyContext
    {
        // This maps to the table that stores keys.
        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

        public DSEUDataProtectionKeysDbContext(DbContextOptions<DSEUDataProtectionKeysDbContext> options) : base(options) { }
    }
}
