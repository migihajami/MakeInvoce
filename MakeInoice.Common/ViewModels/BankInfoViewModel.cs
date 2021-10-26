using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeInoice.Common.ViewModels
{
    public class BankInfoViewModel
    {
        public int BankInfoID { get; set; }

        [Required]
        public string BankName { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int BankAddressID { get; set; }

        [Required]
        public string Swift { get; set; }

        [Required]
        public string AccountNumber { get; set; }

    }
}
