using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeInvoice.Common.ViewModels
{
    public class TokenViewModel
    {
        public TokenViewModel()
        {

        }

        public TokenViewModel(string token, string refreshToken, DateTime expire, DateTime refreshExpire)
        {
            Token = token;
            RefreshToken = refreshToken;
            TokenExpireDate = expire;
            RefreshTokenExpireDate = refreshExpire;
        }

        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime TokenExpireDate { get; set; }
        public DateTime RefreshTokenExpireDate { get; set; }
    }
}
