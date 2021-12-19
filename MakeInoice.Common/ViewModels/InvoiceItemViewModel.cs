using System.ComponentModel.DataAnnotations;

namespace MakeInvoice.Common.ViewModels
{
    /// <summary>
    /// Invoice Item View Model
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-18</date>
    public class InvoiceItemViewModel
    {
        public int InvoiceItemID { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int InvoiceID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Info { get; set; }

        [Required]
        [MaxLength(50)]
        public string UnitType { get; set; }

        [Required]
        public decimal UnitCount { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

    }
}