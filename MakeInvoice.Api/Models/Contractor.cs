using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeInvoice.Api.Models
{
    [Table("Contractor")]
    public class Contractor: Company
    {
        [MaxLength(250)]
        public string Name { get; set; }

        public string Description { get; set; }

    }
}

