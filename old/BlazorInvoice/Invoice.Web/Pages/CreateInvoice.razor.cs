namespace Invoice.Web.Pages
{
    public partial class CreateInvoice
    {
        private static Invoice.Models.Invoice? _invoice { get; set; }
        static CreateInvoice()
        {
            _invoice ??= new Invoice.Models.Invoice()
            {
                CustomerInfo = new Models.Customer() { },
                Items = new List<Models.InvoiceItem>() { new Models.InvoiceItem() { ProductServiceDescription = "CoCo", UnitCounts = 8, UnitPrice = 12 } },
                Payments = new List<Models.InvoicePayment>() { },
            };
        }
        private void AddNewItem()
        {
            if (_invoice == null)
                _invoice = new Models.Invoice() { };
            if (_invoice.Items == null)
                _invoice.Items = new List<Models.InvoiceItem>() { };
            _invoice.Items.Add(new Models.InvoiceItem() { });
        }


        public CreateInvoice()
        {


            //if (_invoice != null)
            //    return;
            //_invoice = new Invoice.Models.Invoice();
        }
    }
}
