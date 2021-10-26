using AutoMapper;
using MakeInoice.Common.ViewModels;
using MakeInvoice.Api.Interfaces;
using MakeInvoice.Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeInvoice.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-26</date>
    /// <seealso cref="MakeInvoice.Api.Controllers.MakeInvoiceController" />
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("[controller]/[action]")]
    public class ContractorController : MakeInvoiceController
    {
        private readonly IContractorRepository _contractorRepo;
        private readonly IMapper _mapper;

        public ContractorController(IContractorRepository contractorRepo, IMapper mapper)
        {
            _contractorRepo = contractorRepo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<List<ContractorViewModel>>> GetAll()
        {
            var contractors = await _contractorRepo.FindAllAsync(c => c.OwnerID == GetUserID());
            var result = _mapper.Map<List<Contractor>, List<ContractorViewModel>>(contractors);
            return new OkObjectResult(result);
        }

        [HttpPost]
        public async Task<ActionResult<ContractorViewModel>> Get(int contractorID)
        {
            var contractor = await _contractorRepo.FindAsync(a => a.ID == contractorID && a.OwnerID == GetUserID());
            if (contractor == null)
                return NotFound($"Contractor whith ID = '{contractorID}' doesn't exist");

            return new OkObjectResult(contractor);
        }

        [HttpPost]
        public async Task<ActionResult<ContractorViewModel>> Add(ContractorViewModel model)
        {
            if (!ModelState.IsValid)
                return new BadRequestObjectResult("Model has errors");

            var contractor = _mapper.Map<ContractorViewModel, Contractor>(model);
            contractor.OwnerID = GetUserID();
            contractor = await _contractorRepo.CreateAsync(contractor);
            return new OkObjectResult(_mapper.Map<Contractor, ContractorViewModel>(contractor));
        }

        [HttpPost]
        public async Task<ActionResult> Update(ContractorViewModel model)
        {
            var contractor = await _contractorRepo.FindAsync(a => a.ID == model.ContractorID && a.OwnerID == GetUserID());
            if (contractor == null)
                return NotFound($"Contractor whith ID = '{model.ContractorID}' doesn't exist");

            await _contractorRepo.UpdateAsync(_mapper.Map<ContractorViewModel, Contractor>(model));
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int contractorID)
        {
            var contractor = await _contractorRepo.FindAsync(a => a.ID == contractorID && a.OwnerID == GetUserID());
            if (contractor == null)
                return NotFound($"Contractor whith ID = '{contractorID}' doesn't exist");

            await _contractorRepo.DeleteAsync(contractor);
            return Ok();
        }
    }
}
