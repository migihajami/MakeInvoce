using AutoMapper;
using MakeInvoice.Common.ViewModels;
using MakeInvoice.Api.Interfaces;
using MakeInvoice.Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MakeInvoice.Api.Controllers
{
    /// <summary>
    /// Company Controller
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-18</date>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("[controller]/[action]")]
    public class CompanyController : MakeInvoiceController
    {
        private readonly ICompanyRepository _companyRepo;
        private readonly IAddressRepository _addressRepo;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyRepository companyRepo, IAddressRepository addressRepo, IMapper mapper)
        {
            _companyRepo = companyRepo;
            _addressRepo = addressRepo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<List<CompanyViewModel>>> CompanyList()
        {
            var model = await _companyRepo
                .FindAllAsync(a => a.OwnerID == GetUserID());

            return new OkObjectResult(_mapper.Map<List<Company>, List<CompanyViewModel>>(model));
        }

        [HttpPost]
        public async Task<ActionResult<CompanyViewModel>> Get(int companyID)
        {
            var model = await _companyRepo.
                FindAsync(a => a.ID == companyID && a.OwnerID == GetUserID());

            return new OkObjectResult(_mapper.Map<Company, CompanyViewModel>(model));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CompanyViewModel model)
        {
            var company = _mapper.Map<CompanyViewModel, Company>(model);
            company.OwnerID = GetUserID();
            company.InsertDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                await _companyRepo.CreateAsync(company);
                return new OkObjectResult(_mapper.Map<Company, CompanyViewModel>(company));
            }

            return BadRequest(ModelState);
        }


        [HttpPost]
        public async Task<ActionResult<CompanyViewModel>> Update(CompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isExists = _companyRepo.FindAsync(a => a.ID == model.CompanyID && a.OwnerID == GetUserID()) != null;
                if (!isExists)
                    return BadRequest("Company doesn't exist");

                var company = _mapper.Map<CompanyViewModel, Company>(model);
                company.OwnerID = GetUserID();
                await _companyRepo.UpdateAsync(company);
                return new OkObjectResult(model);
            }

            return BadRequest(ModelState);
        }


    }
}
