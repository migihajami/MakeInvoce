using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MakeInoice.Common.ViewModels
{
    /// <summary>
    /// Invoice View Model
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-18</date>
    public class InvoiceViewModel
    {
        public int InvoiceID { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        [MaxLength(3)]
        public string Currency { get; set; }

        [Required]
        public DateTime InvoiceDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public bool VatApplicable { get; set; }

        public int VatPercentage { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int CompanyID { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ContractorID { get; set; }
    }
}
