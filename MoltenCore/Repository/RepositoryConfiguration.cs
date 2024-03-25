using Microsoft.Extensions.Configuration;

namespace MoltenCore.Repository
{
    public class RepositoryConfiguration
    {
        public RepositoryConfiguration(
            string connectionString, 
            string schema, 
            byte retryMaxCount = defaultRetryMaxCount, 
            int retryMaxDelay = defaultRetryMaxDelay, 
            IEnumerable<int>? retryErrorNumbersToAdd = null, 
            string migrationHistoryTable = defaultMigrationHistoryTable)
        {
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            Schema = schema ?? throw new ArgumentNullException(nameof(schema));

            if (retryMaxCount > 0)
            {
                RetryMaxCount = retryMaxCount;
                RetryMaxDelay = retryMaxDelay;
                RetryErrorNumbersToAdd = retryErrorNumbersToAdd;
            }
            else
            {
                RetryMaxCount = 0;
                RetryMaxDelay = 0;
            }

            MigrationHistoryTable = migrationHistoryTable ?? throw new ArgumentNullException(nameof(migrationHistoryTable));
        }

        public RepositoryConfiguration(IConfigurationSection configSection)
        {
            ConnectionString = configSection.GetValue<string>("ConnectionString") ?? throw new Exception("ConnectionString is not set");
            Schema = configSection.GetValue<string>("Schema") ?? throw new Exception("Schema is not set");
            RetryMaxCount = configSection.GetValue("RetryMaxCount", defaultRetryMaxCount);
            RetryMaxDelay = configSection.GetValue("RetryMaxDelay", defaultRetryMaxDelay);
            RetryErrorNumbersToAdd = configSection.GetValue<IEnumerable<int>?>("RetryErrorNumbersToAdd");
            MigrationHistoryTable = configSection.GetValue("MigrationHistoryTable", defaultMigrationHistoryTable) ?? throw new Exception("MigrationHistoryTable is not set");
        }


        /// <summary>
        /// Database connection string
        /// </summary>
        public string ConnectionString { get; }

        /// <summary>
        /// Schema or namespace
        /// </summary>
        public string Schema { get; }

        /// <summary>
        /// The maximum number of retry attempts. If Re
        /// </summary>
        public int RetryMaxCount { get; }

        /// <summary>
        /// The maximum delay between retries in milliseconds.
        /// </summary>
        public int RetryMaxDelay { get; }

        /// <summary>
        /// Additional error numbers that should be considered transient.
        /// </summary>
        public IEnumerable<int>? RetryErrorNumbersToAdd { get; }

        /// <summary>
        /// Migration history table name
        /// </summary>
        public string MigrationHistoryTable { get; }

        private const byte defaultRetryMaxCount = 6;
        private const int defaultRetryMaxDelay = 10000;
        private const string defaultMigrationHistoryTable = "__EFMigrationsHistory";
    }
}

