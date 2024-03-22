using Microsoft.EntityFrameworkCore;

namespace MoltenCore.Boilerplate.Repository
{
    public class BoilerplateReadOnlyDbContext : BoilerplateDbContext // Is there a simple way to do the same without breaking Liskov principle?
    {
        public BoilerplateReadOnlyDbContext()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }        

        private new static int SaveChanges()
        {
            throw new InvalidOperationException("This context is read-only.");
        }

        private new static int SaveChanges(bool acceptAll)
        {
            throw new InvalidOperationException("This context is read-only.");
        }

        private new static Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            throw new InvalidOperationException("This context is read-only.");
        }

        private new static Task<int> SaveChangesAsync(bool acceptAll, CancellationToken token = default)
        {
            throw new InvalidOperationException("This context is read-only.");
        }
    }
}
