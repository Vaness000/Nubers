namespace DataLayer
{
    public static class Check
    {
        public static void ArgumentNotNull(object paramValue, string paramName)
        {
            if(paramValue is null)
            {
                throw new ArgumentNullException(paramName);
            }
        }
    }
}
