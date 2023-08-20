namespace DataLayer
{
    /// <summary>
    /// Базовый класс для реализации работы с числами.
    /// </summary>
    public interface IDataProvider
    {
        #region Public Methods

        /// <summary>
        /// Сохраняет тестовые данные в провайдер данных.
        /// </summary>
        /// <param name="numbers">Данные для сохранения.</param>
        /// <param name="cancellationToken">Объект, который позволяет отменить асинхронную задачу.</param>
        /// <returns>Асинхронная задача.</returns>
        Task StoreFakeDataAsync(IEnumerable<int> numbers, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получает все тестовые данные из провайдера данных.
        /// </summary>
        /// <param name="cancellationToken">Объект, который позволяет отменить асинхронную задачу.</param>
        /// <returns>Список чисел, получаемых из провайдера данных.</returns>
        IAsyncEnumerable<int> GetAllNumbersAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Получает количество повторений для чисел.
        /// </summary>
        /// <returns>Словарь для хранения числа и его количества повторений.</returns>
        Task<Dictionary<int, int>> GetFrequencyNumbersAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Получает количество повторений для числа.
        /// </summary>
        /// <param name="number">Число для поиска</param>
        /// <param name="cancellationToken">Объект, который позволяет отменить асинхронную задачу.</param>
        /// <returns>Количество повторений для числа.</returns>
        Task<int?> GetFrequenceByNumber(int number, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получает список чисел по количеству повторений.
        /// </summary>
        /// <param name="amount">Количество повторений.</param>
        /// <param name="cancellationToken">Объект, который позволяет отменить асинхронную задачу.</param>
        /// <returns>Список чисел с указанным количеством повторений.</returns>
        IAsyncEnumerable<int> GetNumberByFrequenceAsync(int amount, CancellationToken cancellationToken = default);

        

        #endregion
    }
}
