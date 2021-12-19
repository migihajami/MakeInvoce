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
    /// Invoice controlle
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-27</date>
    /// <seealso cref="MakeInvoice.Api.Controllers.MakeInvoiceController" />
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("[controller]/[action]")]
    public class InvoiceController : MakeInvoiceController
    {
        private readonly IInvoiceRepository _invoiceRepo;
        private readonly IMapper _mapper;

        public InvoiceController(IInvoiceRepository invoiceRepo, IMapper mapper)
        {
            _invoiceRepo = invoiceRepo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<List<InvoiceViewModel>>> GetAll()
        {
            var invoices = await _invoiceRepo.FindAllAsync(i => i.OwnerID == GetUserID());
            return new OkObjectResult(_mapper.Map<List<Invoice>, List<InvoiceViewModel>>(invoices));
        }

        [HttpPost]
        public async Task<ActionResult<InvoiceViewModel>> Get(int invoiceID)
        {
            var invoice = await _invoiceRepo.FindAsync(i => i.InvoiceID == invoiceID && i.OwnerID == GetUserID());
            if (invoice == null)
                return NotFound($"Invoice whith ID = '{invoiceID}' doesn't exist");

            return new OkObjectResult(_mapper.Map<Invoice, InvoiceViewModel>(invoice));
        }

        [HttpPost]
        public async Task<ActionResult<InvoiceViewModel>> Add(InvoiceViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model state is not valid");

            var invoice = _mapper.Map<InvoiceViewModel, Invoice>(model);
            invoice.OwnerID = GetUserID();
            invoice = await _invoiceRepo.CreateAsync(invoice);
            return new OkObjectResult(_mapper.Map<Invoice, InvoiceViewModel>(invoice));
        }

        [HttpPost]
        public async Task<ActionResult> Update(InvoiceViewModel model)
        {
            var invoice = await _invoiceRepo.FindAsync(i => i.InvoiceID == model.InvoiceID && i.OwnerID == GetUserID());
            if (invoice == null)
                return NotFound($"Invoice whith ID = '{model.InvoiceID}' doesn't exist");

            invoice = _mapper.Map<InvoiceViewModel, Invoice>(model);
            invoice.OwnerID = GetUserID();
            await _invoiceRepo.UpdateAsync(invoice);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int invoiceID)
        {
            var invoice = await _invoiceRepo.FindAsync(i => i.InvoiceID == invoiceID && i.OwnerID == GetUserID());
            if (invoice == null)
                return NotFound($"Invoice whith ID = '{invoiceID}' doesn't exist");

            await _invoiceRepo.DeleteAsync(invoice);
            return Ok();
        }
    }
}
