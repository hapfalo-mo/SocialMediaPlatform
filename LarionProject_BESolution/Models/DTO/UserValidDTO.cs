using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class UserValidDTO
    {
        public string accessToken { get;set;}
        public int userId { get;set; }
        public short role { get; set; } 
        public string AvatarUrl { get; set; }
        public string Username { get;set; }
    }
}
