using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeInvoice.Api.Models
{
    [Table("Company")]
    public class Company
    {
        [Key]
        public int ID { get; set; }

        public string OwnerID { get; set; }

        public IdentityUser Owner { get; set; }

        [MaxLength(250)]
        public string LegalName { get; set; }

        public int LegalAddressID { get; set; }

        public Address LegalAddress { get; set; }

        public int PostalAddressID { get; set; }

        public Address PostalAddress{ get; set; }

        [MaxLength(250)]
        public string EmailAddress { get; set; }

        [MaxLength(50)]
        public string RegNumber { get; set; }

        [MaxLength(50)]
        public string VatNumber { get; set; }

        [MaxLength(150)]
        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime InsertDate { get; set; }
    }
}

