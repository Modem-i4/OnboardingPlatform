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
        public DateTime Created { get; set; }

        UserRefreshToken()
        {
            Expires = DateTime.UtcNow.AddDays(15);  
            Created = DateTime.UtcNow;  
        }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
