// namespace InvoiceForms.DependencyInfra
using Business.BusinessManagers;
using Business.Interfaces;
using DataAccess.ApplicDbContext;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace InvoiceForms.DependencyInfra
{
    internal static class Dependency
    {
        internal static void InitialiseerDI(out IClientManager clientManager,
            out IInvoiceManager invoiceManager)
        {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true);

            var config = configBuilder.Build();

            var connectionstring = config.GetConnectionString("StandaardverBInding");

            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddScoped<IClientManager, ClientManager>()
                .AddScoped<IInvoiceManager, InvoiceManager>()
                .AddScoped<ICountryManager, CountryManager>()
                .AddScoped<IInvoiceRepository, InvoiceRepository>()
                .AddScoped<IClientRepository, ClientRepository>()
                .AddScoped<ICountryRepository, CountryRepository>()
                .AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionstring))
                .BuildServiceProvider();

            invoiceManager = serviceProvider.GetService<IInvoiceManager>();
            clientManager = serviceProvider.GetService<IClientManager>();

        }
    }
}
