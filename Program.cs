using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TestEFCore
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var connectionString = "server=localhost;database=postgres;port=5432;uid=postgres;pwd=senninbankai@;";
            var services = new ServiceCollection();
            services
                .AddDbContextPool<TestEFCoreContext>(dbContextOptions =>
                {
                    dbContextOptions.UseNpgsql(connectionString);
                })
                .AddSingleton<IClientRepository, ClientRepository>()
                .AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddSingleton(typeof(IRepositoryUnityOfWork<>), typeof(RepositoryUnitOfWork<>));

            var provider = services.BuildServiceProvider();

            // Generic Repository Pattern
            var clientRepository = provider.GetService<IGenericRepository<Client>>();
            var client = clientRepository.GetByID(1);

            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(client));

            // Generic Repository Pattern With predicative
            var clients = clientRepository.Get(filter => filter.RegisterDate == DateTime.Today);
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(client));

            // God mod!
            var clientUnityOfWork = provider.GetService<IRepositoryUnityOfWork<IGenericRepository<Client>>>();

            var clientToChange = clientUnityOfWork.Repository.GetByID(1);
            clientToChange.Name = "XPTO";

            var clientToDelete = clientUnityOfWork.Repository.GetByID(2);
            clientUnityOfWork.Repository.Delete(clientToDelete);

            clientUnityOfWork.Commit();
        }
    }
}
