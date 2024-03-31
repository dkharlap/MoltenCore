using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoltenCore.Repository;

namespace MoltenCore.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddSqlServerDbContext<TDbContext>(this IServiceCollection services, RepositoryConfiguration repositoryConfiguration) where TDbContext : DbContext
        {
            services.AddDbContext<TDbContext>(options => options.UseSqlServer(repositoryConfiguration.ConnectionString, sqlOptions =>
            {
                sqlOptions.MigrationsHistoryTable(repositoryConfiguration.MigrationHistoryTable, repositoryConfiguration.Schema);

                if (repositoryConfiguration.RetryMaxCount > 0)
                {
                    sqlOptions.EnableRetryOnFailure(repositoryConfiguration.RetryMaxCount, TimeSpan.FromMilliseconds(repositoryConfiguration.RetryMaxDelay), repositoryConfiguration.RetryErrorNumbersToAdd);
                }
            }));

            return services;
        }
    }
}
