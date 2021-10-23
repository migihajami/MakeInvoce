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
    public class IdentityController: Controller
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
            if (ModelState.IsValid)
            {
                if ((await _userManager.FindByEmailAsync(model.Email)) == null)
                {
                    var user = new IdentityUser { Email = model.Email, UserName = model.Email };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    user = await _userManager.FindByEmailAsync(model.Email);
                    if (result.Succeeded)
                    {
                        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var confirmationLink = Url.ActionLink("ConfirmEmail", "Identity", new { userId = user.Id, @token = token });
                        await _emailSender.SendEmailAsync("noreply@makeinvoice.online", model.Email, "Confirm email", $"confirmation url: {confirmationLink}");
                        return new OkObjectResult(model.Email);
                    }

                    ModelState.AddModelError("Signup", string.Join("<br />", result.Errors.Select(a => a.Description)));
                    return new BadRequestObjectResult("Wrong model");
                }
            }
            return new BadRequestResult();
        }

        [HttpPost]
        public async Task<ActionResult> Signin(SigninViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                    return new OkResult();
            }
            return BadRequest("Can't login");
        }

        [HttpPost]
        public async Task<ActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
                return new OkObjectResult("Email confirmed");

            return new BadRequestResult();
        }
    }
}
