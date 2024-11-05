using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Likes
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public virtual User UserNavigation {get;set;}
        public virtual Post PostNavigation {get; set;}
    }
}
