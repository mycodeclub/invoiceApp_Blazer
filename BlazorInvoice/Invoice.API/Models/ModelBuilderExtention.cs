using Microsoft.EntityFrameworkCore;

namespace Invoice.API.Models
{
    public static class ModelBuilderExtention
    {

        public static void SeedState(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice.Models.Merchant>().HasData(new Invoice.Models.Merchant()
            {
                UniqueId = Guid.NewGuid(),
                OrgName = "The Computers Shop",
                Address = "Indranagar Lucknow",
                EmailId = "business@computes.com",
                GstNumber = "00000000987678",
                Mobile1 = "+91-94-1515-1515",
                Mobile2 = "000000000",
                OrgLogoUri = @"https://icon2.cleanpng.com/20180417/gfe/kisspng-laptop-computer-mouse-logo-desktop-computers-pc-5ad5eaf0b32950.1664578815239687527339.jpg",
                //BankAccountId=1,
                //AccountDetails = new Invoice.Models.BankAccountInfo()
                //{
                //    UniqueId = 1,
                //    AccountHolderName = "Mohit Garg",
                //    AccountNumber = "32165498700000",
                //    BankName = "ICICI",
                //    CreatedDate = DateTime.Now,
                //    IFSCCode = "ICICI0000987",
                //    LastUpdated = DateTime.Now

                //}
            });
        }
    }
}
