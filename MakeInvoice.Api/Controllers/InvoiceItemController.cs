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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("[controller]/[action]")]
    public class InvoiceItemController : MakeInvoiceController
    {
        private readonly IInvoiceItemRepository _itemRepo;
        private readonly IMapper _mapper;

        public InvoiceItemController(IInvoiceItemRepository itemRepo, IMapper mapper)
        {
            _itemRepo = itemRepo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<List<InvoiceItemViewModel>>> GetAll(int invoiceID)
        {
            var items = await _itemRepo.FindAllAsync(i => i.InvoiceID == invoiceID && i.OwnerID == GetUserID());
            return new OkObjectResult(_mapper.Map<List<InvoiceItem>, List<InvoiceItemViewModel>>(items));
        }

        [HttpPost]
        public async Task<ActionResult<InvoiceItemViewModel>> Get(int invoiceItemID)
        {
            var item = await _itemRepo.FindAsync(i => i.InvoiceItemID == invoiceItemID && i.OwnerID == GetUserID());
            if (item == null)
                return NotFound($"Invoice item with ID = '{invoiceItemID} doesn't exist");

            return new OkObjectResult(_mapper.Map<InvoiceItem, InvoiceItemViewModel>(item));
        }

        [HttpPost]
        public async Task<ActionResult<InvoiceItemViewModel>> Add(InvoiceItemViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model is not valid");

            var item = _mapper.Map<InvoiceItemViewModel, InvoiceItem>(model);
            item.OwnerID = GetUserID();
            item = await _itemRepo.CreateAsync(item);
            return new OkObjectResult(_mapper.Map<InvoiceItem, InvoiceItemViewModel>(item));
        }

        [HttpPost]
        public async Task<ActionResult> Update(InvoiceItemViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model is not valid");

            var item = await _itemRepo.FindAsync(i => i.InvoiceItemID == model.InvoiceItemID && i.OwnerID == GetUserID());
            if (item == null)
                return NotFound($"Invoice item with ID = '{model.InvoiceItemID} doesn't exist");

            item = _mapper.Map<InvoiceItemViewModel, InvoiceItem>(model);
            item.OwnerID = GetUserID();
            await _itemRepo.UpdateAsync(item);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int invoiceItemID)
        {
            var item = await _itemRepo.FindAsync(i => i.InvoiceItemID == invoiceItemID && i.OwnerID == GetUserID());
            if (item == null)
                return NotFound($"Invoice item with ID = '{invoiceItemID} doesn't exist");

            await _itemRepo.DeleteAsync(item);
            return Ok();
        }
    }
}
