﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class UserRefreshToken
    {
        public int Id { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expires { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
