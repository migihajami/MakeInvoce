namespace MakeInvoice.Common.ViewModels
{
    /// <summary>
    /// Company View Model
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-26</date>
    /// <seealso cref="MakeInvoice.Common.ViewModels.CompanyContractorBaseViewModel" />
    public class CompanyViewModel: CompanyContractorBaseViewModel
    {
        public int CompanyID { get; set; }
    }
}
