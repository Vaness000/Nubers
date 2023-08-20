using DataLayer;
using System.Configuration;

namespace WinUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var providerFromAppSettings = ConfigurationManager.AppSettings["Provider"];

            DataProviderBase dataProvider = providerFromAppSettings switch
            {
                "file" => new FileProvider(),
                "db" => new DbProvider(),
                _ => throw new InvalidOperationException("Impossible to determinate data provider")
            };

            try
            {
                await dataProvider.InitAsync();
                Application.Run(new NumbersForm(dataProvider));
            }
            catch(Exception e)
            {
                MessageBox.Show(
                    $"Exception: {e.GetType()}{Environment.NewLine}" +
                    $"Message: {e.Message}{Environment.NewLine}" +
                    $"{e.StackTrace}",
                    "Exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Application.Exit();
            }
        }
    }
}