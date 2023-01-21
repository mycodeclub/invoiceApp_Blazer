using Invoice.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoice.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Invoice.Models.Invoice> Invoices { get; set; }
        public DbSet<Invoice.Models.InvoiceItem> invoiceItems { get; set; }
        public DbSet<Invoice.Models.Customer> Customers { get; set; }
        public DbSet<Invoice.Models.Merchant> Merchants { get; set; }
        public DbSet<Invoice.Models.BankAccountInfo> BankAccountInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
