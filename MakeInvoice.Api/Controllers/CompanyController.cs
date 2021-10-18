using MakeInoice.Common.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeInvoice.Api.Controllers
{
    /// <summary>
    /// Company Controller
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-18</date>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Authorize()]
    public class CompanyController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public CompanyController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CompanyList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get(int copanyID)
        {

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new CompanyViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CompanyViewModel model)
        {
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int companyModelID)
        {
            var model = new CompanyViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CompanyViewModel model)
        {
            return View(model);
        }


    }
}
