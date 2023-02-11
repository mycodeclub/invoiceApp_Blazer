using Microsoft.EntityFrameworkCore;

namespace BlazorServerInvoice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Invoice.Models.Invoice> Invoices { get; set; }
    }
}
