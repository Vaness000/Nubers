namespace DataLayer
{
    /// <summary>
    /// Класс для хранения текстов запросов.
    /// </summary>
    public static class QueryStrings
    {
        #region Queries Strings

        public const string ImportDataQuery = "COPY \"Numbers\" FROM STDIN (FORMAT BINARY)";

        public const string HasValuesQuery = "SELECT EXISTS(SELECT 1 FROM \"Numbers\")";

        public const string GetFrequencyQuery = "SELECT \"Number\", count(\"Number\") FROM \"Numbers\" GROUP BY \"Number\"";

        #endregion
    }
}
