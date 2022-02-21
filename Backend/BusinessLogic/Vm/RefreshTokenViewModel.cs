using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Vm
{
    public class RefreshTokenViewModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public RefreshTokenViewModel() : this("", "") { }
        public RefreshTokenViewModel(string token, string refreshToken)
        {
            Token = token;
            RefreshToken = refreshToken;
        }
    }
}
