using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeInoice.Common.ViewModels
{
    public class BankInfoViewModel
    {
        public int BankInfoID { get; set; }

        public string BankName { get; set; }

        public int BankAddressID { get; set; }

        public int? AddressID { get; set; }
        public AddressViewModel Address { get; set; }

        public string Swift { get; set; }

        public string AccountNumber { get; set; }

    }
}
