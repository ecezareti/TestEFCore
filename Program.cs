using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TestEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "server=localhost;database=postgres;port=5432;uid=postgres;pwd=senninbankai@;";
            var services = new ServiceCollection();
            services
                .AddDbContextPool<TestEFCoreContext>(dbContextOptions =>
                {
                    dbContextOptions.UseNpgsql(connectionString);
                })
                .AddSingleton<IClientRepository, ClientRepository>();
            var provider = services.BuildServiceProvider();

            var clientRepository = provider.GetService<IClientRepository>();

            var client = clientRepository.FindById(1).Result;

            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(client));
            Console.ReadLine();
        }
    }
}
