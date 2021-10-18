using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MakeInvoice.Api.Models
{
    /// <summary>
    /// Invoice model
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-18</date>
    public class Invoice
    {
        public int InvoiceID { get; set; }

        public int CompanyID { get; set; }

        public Company Company { get; set; }

        public int ContractorID { get; set; }

        public Contractor Contractor { get; set; }

        [MaxLength(50)]
        public string Number { get; set; }

        public DateTime InvoiceDate { get; set; }

        public DateTime InsertDate { get; set; }

        public DateTime DueDate { get; set; }

        [MaxLength(3)]
        public string Currency { get; set; }

        public bool VatApplicable { get; set; }

        public int VatPercentage { get; set; }

        public List<InvoiceItem> InvoiceItems { get; set; }

        public bool IsDeleted { get; set; }

    }
}
