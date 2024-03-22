using Microsoft.EntityFrameworkCore;

namespace MoltenCore.Boilerplate.Repository
{
    public class BoilerplateDbContext : DbContext
    {
        public DbSet<DbModels.Boilerplate> Boilerplates { get; set; }
    }
}
