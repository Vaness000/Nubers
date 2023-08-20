namespace DataLayer
{
    /// <summary>
    /// Базовый класс для реализации механизма работы с источником данных.
    /// </summary>
    public abstract class DataProviderBase
    {
        #region Protected Constants

        /// <summary>
        /// Количество записей в последовательности.
        /// </summary>
        protected const int RecordsAmount = 10 * 1000 * 1000;

        #endregion

        #region Private Constants

        /// <summary>
        /// Минимальное значение элемента последовательности
        /// </summary>
        private const int MinValue = 0;

        /// <summary>
        /// Максимальное значение элемента последовательности
        /// </summary>
        private const int MaxValue = 100 * 1000;

        #endregion

        #region Protected Fields

        /// <summary>
        /// Словарь для хранения частоты вхождения чисел в последовательность.
        /// </summary>
        protected Dictionary<int, int> numberFrequency;

        #endregion

        #region Protected Abstract Methods

        /// <summary>
        /// Определяет необходимость создания фейковых данных.
        /// </summary>
        /// <param name="cancellationToken">Объект, который позволяет отменить асинхронную задачу.</param>
        /// <returns>Истина, если провайдер данных пуст, иначе ложь.</returns>
        protected abstract Task<bool> NeedFillDataProviderAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Сохраняет тестовые данные в провайдер данных.
        /// </summary>
        /// <param name="numbers">Данные для сохранения.</param>
        /// <param name="cancellationToken">Объект, который позволяет отменить асинхронную задачу.</param>
        /// <returns>Асинхронная задача.</returns>
        protected abstract Task StoreFakeDataAsync(IEnumerable<int> numbers, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получает количество повторений для чисел.
        /// </summary>
        /// <param name="cancellationToken">Объект, который позволяет отменить асинхронную задачу.</param>
        /// <returns>Словарь для хранения числа и его количества повторений.</returns>
        protected abstract Task<Dictionary<int, int>> GetFrequencyNumbersAsync(CancellationToken cancellationToken = default);

        #endregion

        #region Public Mehtods

        /// <summary>
        /// Выполняет необходимые действия при создании объекта провайдера данных.
        /// </summary>
        /// <param name="cancellationToken">Объект, который позволяет отменить асинхронную задачу.</param>
        /// <returns>Асинхронная задача</returns>
        public async Task InitAsync(CancellationToken cancellationToken = default)
        {
            var numbers = GetNumbers();
            await this.StoreFakeDataAsync(numbers, cancellationToken);
            this.numberFrequency = await this.GetFrequencyNumbersAsync(cancellationToken);
        }

        /// <summary>
        /// Получает количество повторений для чисел.
        /// </summary>
        /// <returns>Словарь для хранения числа и его количества повторений.</returns>
        public IEnumerable<KeyValuePair<int, int>> GetFrequencyNumbers(int recordsAmount)
        {
            return this.numberFrequency.Take(recordsAmount);
        }

        /// <summary>
        /// Получает количество повторений для числа.
        /// </summary>
        /// <param name="number">Число для поиска</param>
        /// <returns>Количество повторений для числа.</returns>
        public int? GetFrequenceByNumber(int number)
        {
            return this.numberFrequency.ContainsKey(number)
                ? this.numberFrequency[number]
                : null;
        }

        /// <summary>
        /// Получает список чисел по количеству повторений.
        /// </summary>
        /// <param name="amount">Количество повторений.</param>
        /// <param name="cancellationToken">Объект, который позволяет отменить асинхронную задачу.</param>
        /// <returns>Список чисел с указанным количеством повторений.</returns>
        public IEnumerable<int> GetNumberByFrequence(int amount)
        {
            foreach (var elem in this.numberFrequency)
            {
                if (elem.Value == amount)
                {
                    yield return elem.Key;
                }
            }
        }

        /// <summary>
        /// Получает 10 самых частых чисел в последовательности.
        /// </summary>
        /// <returns>10 самых частых чисел в последовательности.</returns>
        public IEnumerable<KeyValuePair<int, int>> GetTopTenFrequenceNumbers() => this.numberFrequency.OrderByDescending(x => x.Value).Take(10);

        #endregion

        #region Protected Methods

        /// <summary>
        /// Генерирует последовательность для сохранения в провайдер данных.
        /// </summary>
        /// <returns>Последовательность для сохранения в провайдер данных.</returns>
        protected static IEnumerable<int> GetNumbers()
        {
            Random random = new Random();
            for (int i = 0; i < RecordsAmount; i++)
            {
                yield return random.Next(MinValue, MaxValue);
            }
        }


        #endregion
    }
}
