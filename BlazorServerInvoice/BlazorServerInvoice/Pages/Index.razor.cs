using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace BlazorServerInvoice.Pages
{
    public partial class Index
    {
        private static BAL.InvoiceBAL _invoiceBal { get; set; }
        private static Invoice.Models.Invoice _invoice { get; set; }


        //public override async Task SetParametersAsync(ParameterView parameters)
        //{
        //    if (_invoiceBal == null)
        //        _invoiceBal = new BAL.InvoiceBAL();
        //    if (_invoice == null)
        //        _invoice = _invoiceBal.GetNewInvoiceDTO();

        //}

        protected override void OnInitialized()
        {
            if (_invoiceBal == null)
                _invoiceBal = new BAL.InvoiceBAL();
            if (_invoice == null)
                _invoice = _invoiceBal.GetNewInvoiceDTO();

        }
        private void AddNewItemRow()
        {
            if (_invoice == null)
                _invoice = new Invoice.Models.Invoice() { };
            if (_invoice.Items == null)
                _invoice.Items = new List<Invoice.Models.InvoiceItem>() { };
            _invoice.Items.Add(new Invoice.Models.InvoiceItem() { SNo = _invoice.Items.Count + 1, CreatedDate = DateTime.Now, LastUpdatedDate = DateTime.Now });
        }
        private void AddNewPaymentRow()
        {
            if (_invoice == null)
                _invoice = new Invoice.Models.Invoice() { };
            if (_invoice.Payments == null)
                _invoice.Payments = new List<Invoice.Models.InvoicePayment>() { };
            _invoice.Payments.Add(new Invoice.Models.InvoicePayment() { SNo = _invoice.Payments.Count + 1, CreatedDate = DateTime.Now, LastUpdated = DateTime.Now });
        }

        private void NewInvoice() { _invoice = _invoiceBal.GetNewInvoiceDTO(); }

        private void RemoveItemRow(int SNo)
        {
            var itemToRemove = _invoice.Items.Where(i => i.SNo.Equals(SNo)).FirstOrDefault();
            if (itemToRemove != null)
                _invoice.Items.Remove(itemToRemove);
            var count = 1;
            _invoice.Items.ForEach(i => { i.SNo = count++; });
        }
        private void RemovePaymentRow(int SNo)
        {
            var paymentToRemove = _invoice.Payments.Where(i => i.SNo.Equals(SNo)).FirstOrDefault();
            if (paymentToRemove != null)
                _invoice.Payments.Remove(paymentToRemove);
            var count = 1;
            _invoice.Payments.ForEach(p => { p.SNo = count++; });
        }
    }
}
