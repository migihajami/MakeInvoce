using MakeInoice.Common.ViewModels;
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
        [HttpPost]
        public async Task<ActionResult> Get(int addressID)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddressViewModel model)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int address)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult> Update(AddressViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
