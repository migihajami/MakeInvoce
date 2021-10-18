using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MakeInvoice.Api.Models
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }

        [MaxLength(150)]
        public string Country { get; set; }

        [MaxLength(150)]
        public string City { get; set; }

        [MaxLength(150)]
        public string Line1 { get; set; }

        [MaxLength(150)]
        public string Line2 { get; set; }

        [MaxLength(20)]
        public string PostalCode { get; set; }

        public List<BankInfo> BankInfos { get; set; }

        public bool IsDeleted { get; set; }

    }
}

