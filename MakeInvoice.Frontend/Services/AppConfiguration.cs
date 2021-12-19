using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeInvoice.Frontend.Services
{
    public class AppConfiguration
    {
        public AppConfiguration(IConfiguration config)
        {
            var conf =  config.GetSection("AppConfiguration");
            ApiUrl = conf["ApiUrl"];
        }

        public string ApiUrl { get; set; }
    }
}
