using MakeInvoice.Api;
using MakeInvoice.Api.Interfaces;
using MakeInvoice.Api.Map;
using MakeInvoice.Api.Repositories;
using MakeInvoice.Api.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeInvoic.Api
{
    /// <summary>
    /// Startup
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-18</date>
    public class Startup
    {
        private string _issuer;
        private string _audience;
        private string _securityKey;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connString = Configuration["ConnectionStrings:DefaultConnection"];
            _issuer = Configuration["Jwt:Issuer"];
            _audience = Configuration["Jwt:Audience"];
            _securityKey = Configuration["Jwt:Key"];
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();


            services.AddDbContext<ApiDbContext>(opt =>
                opt.UseNpgsql(connString));

            services.AddScoped<DbContext, ApiDbContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = _issuer,
                    ValidAudience = _audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityKey))
                };
            });
            //.AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));
            //services.AddScoped<UserManager<IdentityUser>, UserManager<IdentityUser>>();

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IBankInfoRepository, BankInfoRepository>();
            services.AddScoped<IContractorRepository, ContractorRepository>();
            services.AddScoped<IInvoiceItemRepository, InvoiceItemRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();

            services.AddIdentity<IdentityUser, IdentityRole>(options => { }).AddEntityFrameworkStores<ApiDbContext>().AddDefaultTokenProviders();
            services.AddAutoMapper(typeof(Maps));
            services.AddSingleton<IEmailSender, SmtpEmailSender>();
            services.Configure<SmtpOptions>(Configuration.GetSection("Smtp"));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MakeInvoice.Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }
                  });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MakeInvoic.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
