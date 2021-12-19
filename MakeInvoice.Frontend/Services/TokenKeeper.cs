using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeInvoice.Frontend.Services
{
    public class TokenKeeper
    {
        private string _token;

        private DateTime _ExpiredDate;

        public TokenKeeper()
        {
            _ExpiredDate = DateTime.Now.AddSeconds(-1);
        }

        public TokenKeeper(string token, TimeSpan lifeTime)
        {
            RenewToken(token, lifeTime);
        }

        public bool IsExpired => DateTime.Now > _ExpiredDate;

        public string Token
        {
            get
            {
                if (IsExpired)
                    throw new Exception("Token is expired");

                return _token;
            }
        }

        public void RenewToken(string token, TimeSpan lifeTime)
        {
            _token = token;
            _ExpiredDate = DateTime.Now.Add(lifeTime);

        }
    }
}
