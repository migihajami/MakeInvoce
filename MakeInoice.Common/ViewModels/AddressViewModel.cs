namespace MakeInoice.Common.ViewModels
{
    /// <summary>
    /// Address View Model
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-18</date>
    public class AddressViewModel
    {
        public int? AddressID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string PostalCode { get; set; }
    }
}
