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
    /// <date>2021-10-24</date>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("[controller]/[action]")]
    public class AddressController: MakeInvoiceController
    {
        private readonly IAddressRepository _addressRepo;
        private readonly IMapper _mapper;

        public AddressController(IAddressRepository addressRepo, IMapper mapper )
        {
            _addressRepo = addressRepo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<List<AddressViewModel>>> GetAll()
        {
            var addresses = await _addressRepo.FindAllAsync(a => a.OwnerID == GetUserID());
            var result = _mapper.Map<List<Address>, List<AddressViewModel>>(addresses);

            return new OkObjectResult(result);
        }

        [HttpPost]
        public async Task<ActionResult<AddressViewModel>> Get(int addressID)
        {
            var address = await _addressRepo.FindAsync(a => a.AddressID == addressID && a.OwnerID == GetUserID());
            if (address == null)
                return NotFound($"address with ID = '{addressID}' doesn't exist");

            var model = _mapper.Map<Address, AddressViewModel>(address);
            return new OkObjectResult(model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddressViewModel model)
        {
            var address = _mapper.Map<AddressViewModel, Address>(model);
            address.OwnerID = GetUserID();

            var newAddress = await _addressRepo.CreateAsync(address);
            if (newAddress?.AddressID > 0)
                return new OkResult();

            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int addressID)
        {
            var address = await _addressRepo.FindAsync(a => a.AddressID == addressID && a.OwnerID == GetUserID());
            if (address == null)
                return NotFound($"Address with ID = '{addressID}' doesn't exist");

            await _addressRepo.DeleteAsync(address);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Update(AddressViewModel model)
        {
            var address = await _addressRepo.FindAsync(a => a.AddressID == model.AddressID && a.OwnerID == GetUserID());
            if (address == null)
                return NotFound($"Address with ID = '{model.AddressID}' doesn't exist");

            address = _mapper.Map<AddressViewModel, Address>(model);
            await _addressRepo.UpdateAsync(address);
            return Ok();
        }
    }
}
