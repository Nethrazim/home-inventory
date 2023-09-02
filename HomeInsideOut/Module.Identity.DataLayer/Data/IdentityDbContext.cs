using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shared.DataLayer.Models;
using Shared.DataLayer.Persistence;

namespace Module.Identity.DataLayer.Data
{
    public partial class IdentityDbContext : ModuleDbContext
    {
        protected override string Schema => string.Empty;

        private readonly IConfiguration Configuration;
        public IdentityDbContext(IConfiguration configuration, DbContextOptions<IdentityDbContext> options)
            : base(options)
        {
            Configuration = configuration;
        }
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DbConnectionString"));
            }
        }
    }
}
