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

        public RepositoryConfiguration(IConfigurationSection configSection, bool readOnly = false, ConfigurationKeys? configurationKeys = null)
        {
            configurationKeys ??= new ConfigurationKeys();

            ConnectionString = readOnly ?
                configSection[configurationKeys.ConnectionStringReadOnly] ?? throw new Exception($"{configurationKeys.ConnectionStringReadOnly} is not set") :
                configSection[configurationKeys.ConnectionString] ?? throw new Exception($"{configurationKeys.ConnectionString} is not set");

            Schema = configSection[configurationKeys.Schema] ?? throw new Exception($"{configurationKeys.Schema} is not set");
            RetryMaxCount = configSection.GetValue(configurationKeys.RetryMaxCount, defaultRetryMaxCount);
            RetryMaxDelay = configSection.GetValue(configurationKeys.RetryMaxDelay, defaultRetryMaxDelay);
            RetryErrorNumbersToAdd = configSection.GetValue<IEnumerable<int>?>(configurationKeys.RetryErrorNumbersToAdd);
            MigrationHistoryTable = configSection.GetValue(configurationKeys.MigrationHistoryTable, defaultMigrationHistoryTable) ?? throw new Exception("MigrationHistoryTable is not set");
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

        public class ConfigurationKeys(
            string connectionString = "CONNECTION_STRING",
            string connectionStringReadOnly = "CONNECTION_STRING_READ_ONLY",
            string schema = "SCHEMA",
            string retryMaxCount = "RETRY_MAX_COUNT",
            string retryMaxDelay = "RETRY_MAX_DELAY",
            string retryErrorNumbersToAdd = "RETRY_ERROR_NUMBERS_TO_ADD",
            string migrationHistoryTable = "MIGRATION_HISTORY_TABLE")
        {
            public string ConnectionString { get; init; } = connectionString;
            public string ConnectionStringReadOnly { get; init; } = connectionStringReadOnly;
            public string Schema { get; init; } = schema;
            public string RetryMaxCount { get; init; } = retryMaxCount;
            public string RetryMaxDelay { get; init; } = retryMaxDelay;
            public string RetryErrorNumbersToAdd { get; init; } = retryErrorNumbersToAdd;
            public string MigrationHistoryTable { get; init; } = migrationHistoryTable;
        }
    }
}

