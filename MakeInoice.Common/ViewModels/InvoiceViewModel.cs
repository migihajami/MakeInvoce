using System;
using System.Collections.Generic;

namespace MakeInoice.Common.ViewModels
{
    /// <summary>
    /// Invoice View Model
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-18</date>
    public class InvoiceViewModel
    {
        public string Number { get; set; }

        public string Currency { get; set; }

        public DateTime InvoiceDate { get; set; }

        public DateTime DueDate { get; set; }

        public bool VatApplicable { get; set; }

        public int VatPercentage { get; set; }

        public List<InvoiceItemViewModel> InvoiceItems { get; set; }

        public int CompanyID { get; set; }

        public int ContractorID { get; set; }
    }
}
