using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Invoice.Models
{
    public class Invoice
    {
        [Key]
        public int UniqueId { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer CustomerInfo { get; set; }
        public DateTime InvoiceDate { get; set; }
        [Display(Name = "Invoice No.")]
        public string InvoiceNumber { get; set; }
        public string Description { get; set; }


        public decimal GrandTotal { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public string DiscountTypeName { get; set; }
        public decimal BillableAmountAfterDiscount { get; set; }


        public decimal TotalPaid { get; set; }
        public decimal RemainingBalance { get; set; }



        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsBillingCompleted { get; set; }

        [NotMapped]
        public List<InvoiceItem> Items { get; set; }
        [NotMapped]
        public List<InvoicePayment> Payments { get; set; }
    }
}
