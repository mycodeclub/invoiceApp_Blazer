namespace BlazorServerInvoice.BAL
{
    public class InvoiceBAL
    {
        public Invoice.Models.Invoice GetNewInvoiceDTO()
        {
            return new Invoice.Models.Invoice()
            {
                UniqueId = new Guid(),
                CustomerInfo = new Invoice.Models.Customer() { },
                Items = new List<Invoice.Models.InvoiceItem>()
                {
                    new Invoice.Models.InvoiceItem()
                    {
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now
                    }
                },
                Payments = new List<Invoice.Models.InvoicePayment>()
                {
                    //new Invoice.Models.InvoicePayment()
                    //{
                    //    CreatedDate = DateTime.Now,
                    //    LastUpdated = DateTime.Now
                    //}
                },
                CreatedDate = DateTime.Now,
                LastUpdated = DateTime.Now,
            };
        }
    }
}
