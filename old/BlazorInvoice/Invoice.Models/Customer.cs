using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Models
{
    public class Customer
    {
        [Key]
        public int UniqueId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Mobile1 { get; set; }
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Mobile2 { get; set; }
        public string EmailId { get; set; }
        public string GstNumber { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
