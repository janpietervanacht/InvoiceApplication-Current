using DataAccess.ApplicDbContext;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OutgoingInvoiceBatch.BatchCode;
using OutgoingInvoiceBatch.Interfaces;
using System;
using System.IO;

namespace OutgoingInvoiceBatch
{
    class Program
    {
        static void Main(string[] args)
        {
            IOutgoingInvoiceManager outgoingInvoiceBatch;
            outgoingInvoiceBatch = InitialiseerDI();

            //---------------------------------------------------- 

            Console.WriteLine("Starting creating file with big outgoing invoices");
            var errorCode = outgoingInvoiceBatch.CreateOutgBigInvoiceFile();
            Console.WriteLine($"Return code aanmaak grote uitgaande facturen: {errorCode}\n");

            Console.WriteLine("Starting creating file with small outgoing invoices");
            errorCode = outgoingInvoiceBatch.CreateOutgSmallInvoiceFile();
            Console.WriteLine($"Return code aanmaak grote kleine facturen: {errorCode}\n");

            Console.WriteLine($"Return code aanmaak uitgaande facturen: {errorCode}");

            Console.ReadKey();
        }

        private static IOutgoingInvoiceManager InitialiseerDI()
        {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true);

            var config = configBuilder.Build();

            var connectionstring = config.GetConnectionString("StandaardConnectie");

            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddScoped<IOutgoingInvoiceManager, OutgoingInvoiceManager>()
                 .AddScoped<IClientRepository, ClientRepository>()
                 .AddScoped<IInvoiceRepository, InvoiceRepository>()
                .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionstring))
                .BuildServiceProvider();

            var invoiceBGManager = serviceProvider.GetService<IOutgoingInvoiceManager>();
            return invoiceBGManager;

        }

    }
}
