using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Invoice.Models
{
    public class Invoice
    {
        [Key]
        public Guid UniqueId { get; set; }
        public int InvoiceNo { get; set; }
        public Guid MerchantId { get; set; }
        [ForeignKey("MerchantId")]
        public Merchant? Merchant { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer CustomerInfo { get; set; }
        public DateTime InvoiceDate { get; set; }
        [Display(Name = "Invoice No.")]
        public string InvoiceNumber { get; set; }
        public string Description { get; set; }


        public decimal Total { get { return Items.Sum(i => i.TotalPrice); } }
        public decimal TaxPercentage { get; set; }
        public decimal TaxAmount { get { return (TaxPercentage * Total) / 100; } }
        public decimal GrandTotal { get { return Total + TaxAmount; } }
        public decimal DiscountAmount { get; set; }
        public string DiscountPercentage
        {
            get
            {
                return GrandTotal > 0 ?
                            DiscountAmount > 0 ?
                                ((DiscountAmount / GrandTotal) * 100).ToString("#,0.00") + "%"
                                : 0.ToString() + "%"
                            : "0";
            }
        }
        public string? DiscountTypeName { get; set; }
        public decimal BillableAmountAfterDiscount { get { return GrandTotal - DiscountAmount; } }

        public decimal TotalPaid { get { return Payments.Sum(p => p.ReceivedAmount); } }
        public decimal RemainingBalance { get { return BillableAmountAfterDiscount - TotalPaid; } }

        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsBillingCompleted { get; set; }

        [NotMapped]
        public List<InvoiceItem>? Items { get; set; }
        [NotMapped]
        public List<InvoicePayment>? Payments { get; set; }
    }
}
