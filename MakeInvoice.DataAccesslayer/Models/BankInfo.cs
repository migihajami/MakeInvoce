using System.ComponentModel.DataAnnotations;

namespace MakeInvoice.DataAccesslayer.Models
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
    }
}

