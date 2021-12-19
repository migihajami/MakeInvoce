using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using MakeInvoice.Common.ViewModels;

namespace MakeInvoice.Api.Utils
{
    public class TokenGenerator
    {
        private readonly IConfiguration _configuration;
        private readonly string key;
        private readonly string issuer;
        private readonly string audience;
        private readonly double lifetime;
        private readonly double refreshLifetime;

        public TokenGenerator(IConfiguration configuration)
        {
            issuer = configuration["Jwt:Issuer"];
            audience = configuration["Jwt:Audience"];
            key = configuration["Jwt:Key"];
            lifetime = int.Parse(configuration["Jwt:TokenLifetime"]);
            refreshLifetime = int.Parse(configuration["Jwt:RefreshTokenLifetime"]);
        }

        protected (string, DateTime) GenerateToken(bool isRefresh, IEnumerable<Claim> claims)
        {
            var theKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds = new SigningCredentials(theKey, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(isRefresh ? refreshLifetime : lifetime);
            var token = new JwtSecurityToken(issuer, audience, claims, expires: expires, signingCredentials: creds);
            return (new JwtSecurityTokenHandler().WriteToken(token), expires);
        }

        public TokenViewModel GenerateFullToken(IEnumerable<Claim> claims)
        {
            var token = GenerateToken(false, claims);
            var refresh = GenerateToken(true, claims);

            return new TokenViewModel(token.Item1, refresh.Item1, token.Item2, refresh.Item2);
            
        }
    }
}
