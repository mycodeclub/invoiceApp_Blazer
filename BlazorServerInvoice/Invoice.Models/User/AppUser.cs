using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.AspNet.Identity.EntityFramework;

namespace Invoice.Models.User
{
    public class AppUser //: IdentityUser
    {
        //[Key]
        //public override string Id { get; set; }
        public int? AddressId { get; set; }

        //[ForeignKey("AddressId")]
        //public Address Address { get; set; }
        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public string ConfirmPassword { get; set; }
    }
}
