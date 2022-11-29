using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ClientService
{
    class Program
    {
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<ClientServiceServer, ClientServiceServer>();
                    services.AddHostedService<ClientService>();
                }).Build().Run();
        }
    }
}