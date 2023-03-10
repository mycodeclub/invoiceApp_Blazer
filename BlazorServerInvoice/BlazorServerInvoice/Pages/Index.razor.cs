using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace BlazorServerInvoice.Pages
{
    public partial class Index
    {
        private static BAL.InvoiceBAL _invoiceBal { get; set; }
        


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
            if (Data.staticData._invoice == null)
                Data.staticData._invoice = _invoiceBal.GetNewInvoiceDTO();

        }
        private void AddNewItemRow()
        {
            if (Data.staticData._invoice == null)
                Data.staticData._invoice = new Invoice.Models.Invoice() { };
            if (    Data.staticData._invoice.Items == null)
                Data.staticData._invoice.Items = new List<Invoice.Models.InvoiceItem>() { };
            Data.staticData._invoice.Items.Add(new Invoice.Models.InvoiceItem() { SNo = Data.staticData._invoice.Items.Count + 1, CreatedDate = DateTime.Now, LastUpdatedDate = DateTime.Now });
        }
        private void AddNewPaymentRow()
        {
            if (Data.staticData._invoice == null)
                Data.staticData._invoice = new Invoice.Models.Invoice() { };
            if (Data.staticData._invoice.Payments == null)
                Data.staticData._invoice.Payments = new List<Invoice.Models.InvoicePayment>() { };
            Data.staticData._invoice.Payments.Add(new Invoice.Models.InvoicePayment() { SNo =   Data.staticData._invoice.Payments.Count + 1, CreatedDate = DateTime.Now, LastUpdated = DateTime.Now });
        }


        private void NewInvoice() { Data.staticData._invoice = _invoiceBal.GetNewInvoiceDTO(); }

        private void RemoveItemRow(int SNo)
        {
            var itemToRemove = Data.staticData._invoice.Items.Where(i => i.SNo.Equals(SNo)).FirstOrDefault();
            if (itemToRemove != null)
                Data.staticData._invoice.Items.Remove(itemToRemove);
            var count = 1;
            Data.staticData._invoice.Items.ForEach(i => { i.SNo = count++; });
        }
        private void RemovePaymentRow(int SNo)
        {
            var paymentToRemove = Data.staticData._invoice.Payments.Where(i => i.SNo.Equals(SNo)).FirstOrDefault();
            if (paymentToRemove != null)
                Data.staticData._invoice.Payments.Remove(paymentToRemove);
            var count = 1;
            Data.staticData._invoice.Payments.ForEach(p => { p.SNo = count++; });
        }
    }
}
