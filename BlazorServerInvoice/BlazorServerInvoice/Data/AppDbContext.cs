using Invoice.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerInvoice.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
     //   public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Invoice.Models.Invoice> Invoices { get; set; }
    }
}
