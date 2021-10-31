using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MakeInvoice.Api.Controllers
{
    public class MakeInvoiceController: Controller
    {
        protected string GetUserID()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
