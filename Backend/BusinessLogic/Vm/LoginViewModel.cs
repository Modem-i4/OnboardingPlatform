﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Vm
{
    public class LoginViewModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }    
        public int UserId { get; set; }
    }
}
