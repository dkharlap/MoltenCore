using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoltenCore.Core.Repository;

namespace MoltenCore.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlServer<TDbContext>(
            this IServiceCollection services,
            RepositoryConfiguration configuration)
            where TDbContext : DbContext
        {
            services.AddSingleton(configuration);

            services.AddDbContext<TDbContext>(options =>
                options.UseSqlServer(configuration.ConnectionString, sqlOptions =>
                {
                    sqlOptions.MigrationsHistoryTable(configuration.MigrationHistoryTable, configuration.Schema);

                    if (configuration.RetryMaxCount > 0)
                    {
                        sqlOptions.EnableRetryOnFailure(configuration.RetryMaxCount, TimeSpan.FromMilliseconds(configuration.RetryMaxDelay), configuration.RetryErrorNumbersToAdd);
                    }
                }));

            return services;
        }
    }
}
