using Microsoft.AspNetCore;

namespace employeeshift.api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateWebHostBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .Build();

            using (var scope = host.Services.CreateScope())
            { 
                var services = scope.ServiceProvider;

                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    //Seeding
                }
                catch (Exception x)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(x, "An error occurred in migration");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
    }
}