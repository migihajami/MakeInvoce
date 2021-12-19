using AutoMapper;
using MakeInvoice.Common.ViewModels;
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
    /// Bank Info COntroller
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-26</date>
    /// <seealso cref="MakeInvoice.Api.Controllers.MakeInvoiceController" />
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("[controller]/[action]")]
    public class BankInfoController : MakeInvoiceController
    {
        private readonly IBankInfoRepository _bankRepo;
        private readonly IMapper _mapper;

        public BankInfoController(IBankInfoRepository bankRepo, IMapper mapper)
        {
            _bankRepo = bankRepo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<List<BankInfoViewModel>>> GetAll()
        {
            var bankInfos = await _bankRepo.FindAllAsync(b => b.OwnerID == GetUserID());
            return new OkObjectResult(_mapper.Map<List<BankInfo>, List<BankInfoViewModel>>(bankInfos));
        }

        [HttpPost]
        public async Task<ActionResult<BankInfoViewModel>> Get(int bankInfoID)
        {
            var bankInfo = await _bankRepo.FindAsync(b => b.BankInfoID == bankInfoID && b.OwnerID == GetUserID());
            if (bankInfo == null)
                return NotFound($"Bank Info whith ID = '{bankInfoID}' doesn't exist");

            return new OkObjectResult(_mapper.Map<BankInfo, BankInfoViewModel>(bankInfo));
        }

        [HttpPost]
        public async Task<ActionResult<BankInfoViewModel>> Add(BankInfoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model is not valid");

            var bankInfo = _mapper.Map<BankInfoViewModel, BankInfo>(model);
            bankInfo.OwnerID = GetUserID();
            bankInfo = await _bankRepo.CreateAsync(bankInfo);
            return new OkObjectResult(_mapper.Map<BankInfo, BankInfoViewModel>(bankInfo));
        }

        [HttpPost]
        public async Task<ActionResult> Update(BankInfoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model is not valid");

            var bankInfo = await _bankRepo.FindAsync(b => b.BankInfoID == model.BankInfoID && b.OwnerID == GetUserID());
            if (bankInfo == null)
                return NotFound($"Bank Info with ID = '{model.BankInfoID}' doesn't exist");

            bankInfo = _mapper.Map<BankInfoViewModel, BankInfo>(model);
            bankInfo.OwnerID = GetUserID();
            await _bankRepo.UpdateAsync(bankInfo);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int bankInfoID)
        {
            var bankInfo = await _bankRepo.FindAsync(b => b.BankInfoID == bankInfoID && b.OwnerID == GetUserID());
            if (bankInfo == null)
                return NotFound($"Bank Info with ID = '{bankInfoID}' doesn't exist");

            await _bankRepo.DeleteAsync(bankInfo);
            return Ok();
        }
    }
}
