using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class UserDTO
    {
        public string Username { get; set;}
        public string PasswordHash { get; set;}
        public string re_password_hash { get;set;}
        public string Introduction { get; set;}
        public string Address { get; set; }
        public int Gentle { get; set; }
    }
}
