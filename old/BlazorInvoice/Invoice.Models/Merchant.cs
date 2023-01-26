using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoice.Models
{
    public class Merchant
    {
        [Key]
        public Guid UniqueId { get; set; }

        public string OrgName { get; set; }
        public string OrgLogoUri { get; set; }
        public string Address { get; set; }
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string? Mobile1 { get; set; }
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Mobile2 { get; set; }
        public string EmailId { get; set; }
        public string GstNumber { get; set; }
        // ------------------payment....
        public int ? BankAccountId { get; set; }
        [ForeignKey("BankAccountId")]
        public virtual BankAccountInfo AccountDetails { get; set; }
    }
}