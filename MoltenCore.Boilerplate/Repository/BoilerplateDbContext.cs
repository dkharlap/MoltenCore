using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MoltenCore.Boilerplate.Repository
{
    public class BoilerplateDbContext(DbContextOptions<BoilerplateDbContext> options) : DbContext(options)
    {
        public DbSet<DbModels.Boilerplate> Boilerplates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set schema for DB objects
            if (!string.IsNullOrEmpty(_schema))
                modelBuilder.HasDefaultSchema(_schema);
        }

        private readonly string? _schema = RelationalOptionsExtension.Extract(options).MigrationsHistoryTableSchema;
    }
}
