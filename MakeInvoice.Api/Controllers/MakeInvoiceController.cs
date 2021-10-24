using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeInvoice.Api.Controllers
{
    public class MakeInvoiceController: Controller
    {
        public string GetUserID()
        {
            return User.FindFirst(c => c.Type == "jti")?.Value;
        }
    }
}
