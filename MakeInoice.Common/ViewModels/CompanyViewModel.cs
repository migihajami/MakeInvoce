namespace MakeInoice.Common.ViewModels
{
    /// <summary>
    /// Company View Model
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-18</date>
    public class CompanyViewModel
    {
        public int CompanyID { get; set; }
        public string LegalName { get; set; }
        public string RegNumber { get; set; }
        public string VatNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? LegalAddressID { get; set; }
        public AddressViewModel LegalAdress { get; set; }
        public int? PostalAddressID { get; set; }
        public AddressViewModel PostalAddress { get; set; }
    }
}
