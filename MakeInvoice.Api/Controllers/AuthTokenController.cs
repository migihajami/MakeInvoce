using MakeInoice.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MakeInvoice.Api.Controllers
{
    /// <summary>
    /// Auth Token Controller
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-18</date>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [ApiController]
    public class AuthTokenController : MakeInvoiceController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<IdentityUser> _signinManager;

        public AuthTokenController(UserManager<IdentityUser> userManager, IConfiguration configuration, SignInManager<IdentityUser> signinManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _signinManager = signinManager;
        }

        [Route(template:"AuthToken")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetToken(UserViewModel model)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = _configuration["Jwt:Key"];
            int lifetime = int.Parse(_configuration["Jwt:TokenLifetime"]);


            if (!ModelState.IsValid)
                return BadRequest();

            var signinResult = await _signinManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            if (!signinResult.Succeeded)
                return BadRequest();

            var user = await _userManager.FindByEmailAsync(model.Username);
            if (user == null)
                return BadRequest();

            var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email , user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti , user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id)
                };

            var theKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds = new SigningCredentials(theKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.Now.AddMinutes(lifetime), signingCredentials: creds);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) }); ;
        }
    }
}
