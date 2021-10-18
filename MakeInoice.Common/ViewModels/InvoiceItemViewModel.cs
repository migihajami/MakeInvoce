namespace MakeInoice.Common.ViewModels
{
    /// <summary>
    /// Invoice Item View Model
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-18</date>
    public class InvoiceItemViewModel
    {
        public string Name { get; set; }

        public string Info { get; set; }

        public string UnitType { get; set; }

        public decimal UnitCount { get; set; }

        public decimal UnitPrice { get; set; }

    }
}