using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Invoice.Models
{
    public class InvoicePayment
    {


        [Key]
        public int UniqueId { get; set; }

        [NotMapped]
        public int SNo { get; set; }

        public int BaseInvoiceId { get; set; }
        [ForeignKey("BaseInvoiceId")]

        public Invoice Invoice { get; set; }

        public decimal ReceivedAmount { get; set; }
        public string Description { get; set; }



        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
