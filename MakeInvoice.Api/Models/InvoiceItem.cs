using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MakeInvoice.Api.Models
{
    public class InvoiceItem
    {
        [Key]
        public int InvoiceItemID { get; set; }

        public int InvoiceID { get; set; }

        public Invoice Invoice { get; set; }

        public string Name { get; set; }

        public string Info { get; set; }

        [MaxLength(50)]
        public string UnitType { get; set; }

        public decimal UnitCount { get; set; }

        public decimal UnitPrice { get; set; }

        public bool IsDeleted { get; set; }
        public string OwnerID { get; set; }
        public IdentityUser Owner { get; set; }
    }
}
