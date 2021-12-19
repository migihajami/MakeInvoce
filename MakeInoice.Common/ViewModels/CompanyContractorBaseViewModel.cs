using System.ComponentModel.DataAnnotations;

namespace MakeInvoice.Common.ViewModels
{
    /// <summary>
    /// Company/Contractor Base View Model
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-18</date>
    public abstract class CompanyContractorBaseViewModel
    {
        

        [Required]
        public string LegalName { get; set; }

        [Required]
        public string RegNumber { get; set; }

        public string VatNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int LegalAddressID { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int PostalAddressID { get; set; }
    }
}
