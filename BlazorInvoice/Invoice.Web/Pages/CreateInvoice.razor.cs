namespace Invoice.Web.Pages
{
    public partial class CreateInvoice
    {
        public static Invoice.Models.Invoice? _invoice { get; set; }
        CreateInvoice()
        {
            _invoice ??= new Invoice.Models.Invoice()
            {
                CustomerInfo = new Models.Customer() { },
                Items = new List<Models.InvoiceItem>() { },
                Payments = new List<Models.InvoicePayment>() { },
            };


            //if (_invoice != null)
            //    return;
            //_invoice = new Invoice.Models.Invoice();
        }
    }
}
