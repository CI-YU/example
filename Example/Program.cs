using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Web;
using System;

namespace Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Ū�����w��m���t�m���
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("Nlog.config").GetCurrentClassLogger();

            try
            {
                logger.Info("Init Main");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped program because of exception");
            }
            finally
            {
                LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                // �t�m�ϥ�NLog
                .UseNLog();
    }
}
