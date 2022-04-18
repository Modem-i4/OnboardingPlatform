using DataAccess.Models.Base;
using System;

namespace DataAccess.Models
{
    public class UserRefreshToken: EntityBase
    {
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
