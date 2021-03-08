using DataAccess.ApplicDbContext;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OutgoingExports.Managers;
using System.IO;

namespace OutgoingExports.DependencyInfra
{
    internal static class Dependency
    {
        internal static void InitialiseerDI(ref IOutgoingClientManager outgoingClientManager,
            ref IOutgoingInvoiceManager outgoingInvoiceManager)
        {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true);

            var config = configBuilder.Build();

            var connectionstring = config.GetConnectionString("DefaultVerbinding");

            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddScoped<IOutgoingInvoiceManager, OutgoingInvoiceManager>()
                .AddScoped<IOutgoingClientManager, OutgoingClientManager>()
                .AddScoped<IInvoiceRepository, InvoiceRepository>()
                .AddScoped<IClientRepository, ClientRepository>()
                .AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionstring))
                .BuildServiceProvider();

            outgoingInvoiceManager = serviceProvider.GetService<IOutgoingInvoiceManager>();
            outgoingClientManager = serviceProvider.GetService<IOutgoingClientManager>();

        }
    }
}
