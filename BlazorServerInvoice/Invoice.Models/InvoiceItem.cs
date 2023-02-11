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
    public class InvoiceItem
    {
        [Key]
        public int UniqueId { get; set; }
        
        [NotMapped]
        public int SNo { get; set; }

        public int InvoiceId { get; set; }

        [ForeignKey("InvoiceId")]
        public Invoice Invoice { get; set; }
        public string ProductServiceDescription { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal UnitCounts { get; set; }
        [NotMapped]
        public decimal TotalPrice
        {
            get
            {
                return (UnitPrice * UnitCounts);
            }
        }

        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
