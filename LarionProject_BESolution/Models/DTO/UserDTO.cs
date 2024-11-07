using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class UserDTO
    {
        public string username {get; set;}
        public string password_hash { get; set;}
        public string re_password_hash { get;set;}
        public string introduction { get; set;}
        public string avatar_url { get; set; }
        public string email { get;set;}
        public string phone_number { get;set;}
        public int gentle { get; set; }
    }
}
