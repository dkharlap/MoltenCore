using Microsoft.EntityFrameworkCore;

namespace MoltenCore.Boilerplate.Repository
{
    public class BoilerplateDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<DbModels.Boilerplate> Boilerplates { get; set; }
    }
}
