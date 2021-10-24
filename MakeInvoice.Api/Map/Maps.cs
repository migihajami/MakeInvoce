using AutoMapper;
using MakeInoice.Common.ViewModels;
using MakeInvoice.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeInvoice.Api.Map
{
    public class Maps: Profile
    {
        public Maps()
        {
            CreateMap<Company, CompanyViewModel>().ReverseMap();
            CreateMap<Address, AddressViewModel>().ReverseMap();
            CreateMap<BankInfo, BankInfoViewModel>().ReverseMap();
            CreateMap<Invoice, InvoiceViewModel>().ReverseMap();
            CreateMap<InvoiceItem, InvoiceItemViewModel>().ReverseMap();
            CreateMap<Contractor, ContractorViewModel>().ReverseMap();
        }   
    }
}
