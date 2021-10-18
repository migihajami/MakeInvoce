using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MakeInvoice.DataAccesslayer.Models
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string PostalCode { get; set; }

        public List<BankInfo> BankInfos { get; set; }

        public List<Company> Companies{ get; set; }
    }
}

