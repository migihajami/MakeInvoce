using System;
using System.ComponentModel.DataAnnotations;

namespace MakeInvoice.DataAccesslayer.Models
{
    public class Company
    {
        [Key]
        public int ID { get; set; }

        public string LegalName { get; set; }

        public int LegalAddressID { get; set; }

        public Address LegalAddress { get; set; }

        public int PostalAddressID { get; set; }
        public Address PostalAddress{ get; set; }

        public string EmailAddress { get; set; }

        public string RegNumber { get; set; }

        public string VatNumber { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime InsertDate { get; set; }
    }
}

