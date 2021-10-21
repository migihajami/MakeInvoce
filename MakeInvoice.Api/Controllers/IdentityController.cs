using MakeInoice.Common.ViewModels;
using MakeInvoice.Api.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeInvoice.Api.Controllers
{
    /// <summary>
    /// Identity Controller
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-21</date>
    [ApiController]
    [Route("[controller]/[action]")]
    public class IdentityController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailSender _emailSender;

        public IdentityController(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager, 
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task<ActionResult> Signup(SignupViewModel model)
        {
            await _emailSender.SendEmailAsync("noreply@makeinvoice.com", model.Email, "Makeinvoice: email confirmation", "confirm email");
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult> Signin(SigninViewModel model)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult> ConfirmEmail(string userId, string token)
        {
            throw new NotImplementedException();
        }
    }
}
