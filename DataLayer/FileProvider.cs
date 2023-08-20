using System.Configuration;

namespace DataLayer
{
    /// <summary>
    /// Реализация для работы с файлом.
    /// </summary>
    public class FileProvider : DataProviderBase
    {
        #region Private Fields

        /// <summary>
        /// Путь для файла.
        /// </summary>
        private readonly string filePath;

        #endregion

        #region Constructors

        public FileProvider()
        {
            var path = ConfigurationManager.AppSettings["FilePath"];
            if(path is null)
            {
                throw new InvalidDataException("File path is null");
            }

            this.filePath = path;
        }

        #endregion

        #region DataProviderBaseMembers

        /// <inheritdoc />
        protected override async Task<Dictionary<int, int>> GetFrequencyNumbersAsync(CancellationToken cancellationToken = default)
        {
            var result = new Dictionary<int, int>();
            using var reader = new StreamReader(filePath);
            string? line = null;

            while ((line = await reader.ReadLineAsync()) != null)
            {
                if (int.TryParse(line, out int number))
                {
                    result[number] = result.ContainsKey(number)
                    ? result[number] + 1
                    : 1;
                }
            }

            return result;
        }

        /// <inheritdoc />
        protected override async Task StoreFakeDataAsync(IEnumerable<int> numbers, CancellationToken cancellationToken = default)
        {
            Check.ArgumentNotNull(numbers, nameof(numbers));

            var needToFill = await this.NeedFillDataProviderAsync(cancellationToken);
            if (!needToFill)
            {
                return;
            }

            var lines = numbers.Select(x => x.ToString());

            await File.WriteAllLinesAsync(filePath, lines, cancellationToken);
        }

        /// <inheritdoc />
        protected override async Task<bool> NeedFillDataProviderAsync(CancellationToken cancellationToken = default)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
                return true;
            }

            using var reader = new StreamReader(filePath);
            var line = await reader.ReadLineAsync();
            return line is null;
        }

        #endregion
    }
}
