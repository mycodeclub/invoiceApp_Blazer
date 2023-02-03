using System.Reflection;

namespace BlazorServerInvoice.Pages
{
    public partial class Index
    {
        private static Invoice.Models.Invoice? _invoice { get; set; }
        static Index()
        {
            _invoice ??= new Invoice.Models.Invoice()
            {
                CustomerInfo = new Invoice.Models.Customer() { },
                Items = new List<Invoice.Models.InvoiceItem>() { new Invoice.Models.InvoiceItem() { CreatedDate = DateTime.Now, LastUpdatedDate = DateTime.Now } },
                Payments = new List<Invoice.Models.InvoicePayment>() { new Invoice.Models.InvoicePayment() { CreatedDate = DateTime.Now, LastUpdated = DateTime.Now } },
                CreatedDate = DateTime.Now,
                LastUpdated = DateTime.Now,
            };
        }
        private void AddNewItemRow()
        {
            if (_invoice == null)
                _invoice = new Invoice.Models.Invoice() { };
            if (_invoice.Items == null)
                _invoice.Items = new List<Invoice.Models.InvoiceItem>() { };
            _invoice.Items.Add(new Invoice.Models.InvoiceItem() { CreatedDate = DateTime.Now, LastUpdatedDate = DateTime.Now });
        }
        private void AddNewPaymentRow()
        {
            if (_invoice == null)
                _invoice = new Invoice.Models.Invoice() { };
            if (_invoice.Payments == null)
                _invoice.Payments = new List<Invoice.Models.InvoicePayment>() { };
            _invoice.Payments.Add(new Invoice.Models.InvoicePayment() { CreatedDate = DateTime.Now, LastUpdated = DateTime.Now });
        } 
     }
}
