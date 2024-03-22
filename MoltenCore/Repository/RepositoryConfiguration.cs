namespace MoltenCore.Repository
{
    public class RepositoryConfiguration
    {
        public RepositoryConfiguration(
            string connectionString, 
            string schema, 
            byte retryMaxCount = 6, int retryMaxDelay = 10000, IEnumerable<int>? retryErrorNumbersToAdd = null, 
            string migrationHistoryTable = "__EFMigrationsHistory")
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
    }
}

