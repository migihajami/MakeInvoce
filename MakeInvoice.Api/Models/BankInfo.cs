using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MakeInvoice.Api.Models
{
    public class BankInfo
    {
        [Key]
        public int BankInfoID { get; set; }

        public string BankName { get; set; }

        public int BankAddressID { get; set; }

        public Address Address { get; set; }

        public string Swift { get; set; }

        public string AccountNumber { get; set; }

        public bool IsDeleted { get; set; }
        public string OwnerID { get; set; }
        public IdentityUser Owner { get; set; }    
    }
}

