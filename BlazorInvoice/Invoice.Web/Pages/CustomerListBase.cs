using Invoice.Models;
using Microsoft.AspNetCore.Components;

namespace Invoice.Web.Pages
{
    public class CustomerListBase : ComponentBase
    {

        public List<Invoice.Models.Customer> Customers { get; set; }
        List<Invoice.Models.Customer> GetCustomers()
        {
            System.Threading.Thread.Sleep(5000);
            if (Customers == null)
            {
                Customers = new List<Models.Customer>() { };
                Customers.Add(new Customer() { Name = "Customer 1", Address = "Lucknow", GstNumber = "0000-1111-2222-3333" });
                Customers.Add(new Customer() { Name = "Customer 2", Address = "Kanpur", GstNumber = "0000-1111-2222-4444" });
                Customers.Add(new Customer() { Name = "Customer 3", Address = "Mathura", GstNumber = "0000-1111-2222-5555" });
                Customers.Add(new Customer() { Name = "Customer 1", Address = "Vrindavan", GstNumber = "0000-1111-2222-6666" });
            }
            return Customers;
        }

        //protected override void OnInitialized()
        //{
        //    GetCustomers();
        //    base.OnInitialized();
        //}

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(GetCustomers);
            //      return base.OnInitializedAsync();
        }

    }
}
