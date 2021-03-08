using Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.ApplicDbContext
{
    public class DatabaseContext : IdentityDbContext
    // ApplicationDbContext  / DbSet: gebruiken als je tabellen vanuit de code
    // creëert (CODE FIRST, goed bij intake). Let op: Database wel eerst
    // aanmaken in SQL Server. 
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        // Alle Log tabellen zijn in een andere Database geplaatst
        // en vallen niet meer onder Code First Migration en niet onder ApplicationDbContext.

        //public DbSet<LogDebugInfo> LogDebugInfo { get; set; }
        //public DbSet<LogWarningError> LogWarningError { get; set; }
        //public DbSet<LogApiMessages> LogApiError { get; set; }

        // Creatie van een index op Invoice Number en Client Number: 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client>()
                .HasIndex(i => i.ClientNumber)
                .HasName("Index_ClientNumber")
                .IsUnique();

            modelBuilder.Entity<Invoice>()
                .HasIndex(i => i.InvoiceNumber)
                .HasName("Index_InvoiceNumber")
                .IsUnique();

        }


    }
}
