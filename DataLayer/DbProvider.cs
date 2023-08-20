using Npgsql;
using NpgsqlTypes;
using System.Configuration;

namespace DataLayer
{
    /// <summary>
    /// Реализация для работы с базой данных.
    /// </summary>
    public class DbProvider : DataProviderBase
    {
        #region Private Fields

        /// <summary>
        /// Строка подключения к базе данных.
        /// </summary>
        private readonly string connectionString;

        #endregion

        #region Constructors

        public DbProvider()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Postgre"];
            if(connectionString is null)
            {
                throw new InvalidDataException("Connection string is null");
            }

            this.connectionString = connectionString.ConnectionString;
        }

        #endregion

        #region DataProviderBaseMembers

        /// <inheritdoc />
        protected override async Task<Dictionary<int, int>> GetFrequencyNumbersAsync(CancellationToken cancellationToken = default)
        {
            using var connection = new NpgsqlConnection(connectionString);
            await using var command = new NpgsqlCommand(QueryStrings.GetFrequencyQuery, connection);
            await connection.OpenAsync(cancellationToken);

            var reader = await command.ExecuteReaderAsync(cancellationToken);

            var result = new Dictionary<int, int>();
            while (await reader.ReadAsync(cancellationToken))
            {
                var key = reader.GetInt32(0);
                var value = reader.GetInt32(1);

                result.Add(key, value);
            }

            await connection.CloseAsync();

            return result;
        }

        /// <inheritdoc />
        protected override async Task<bool> NeedFillDataProviderAsync(CancellationToken cancellationToken = default)
        {
            using var connection = new NpgsqlConnection(connectionString);
            await using var command = new NpgsqlCommand(QueryStrings.HasValuesQuery, connection);
            await connection.OpenAsync(cancellationToken);

            var result = await command.ExecuteScalarAsync(cancellationToken);

            await connection.CloseAsync();

            if (result is null)
            {
                throw new InvalidOperationException("Impossible to read data from db");
            }

            return (bool) result;

        }

        /// <inheritdoc />
        protected override async Task StoreFakeDataAsync(IEnumerable<int> numbers, CancellationToken cancellationToken = default)
        {
            var hasData = await this.NeedFillDataProviderAsync(cancellationToken);
            if (hasData)
            {
                return;
            }

            using var connection = new NpgsqlConnection(connectionString);
            await connection.OpenAsync(cancellationToken);

            using (var writer = await connection.BeginBinaryImportAsync(QueryStrings.ImportDataQuery, cancellationToken))
            {
                foreach (var number in numbers)
                {
                    await writer.StartRowAsync(cancellationToken);
                    await writer.WriteAsync(number, NpgsqlDbType.Integer, cancellationToken);
                }

                await writer.CompleteAsync(cancellationToken);
            }

            await connection.CloseAsync();
        }

        #endregion
    }
}
