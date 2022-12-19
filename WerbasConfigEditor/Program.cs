using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XML;
using XML.Contract;

namespace WerbasConfigEditor
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<frmConfigEditor>());
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddTransient<IXmlManager, XmlManager>();
                    services.AddTransient<frmConfigEditor>();
                });
        }
    }
}