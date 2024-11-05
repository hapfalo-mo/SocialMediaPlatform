using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class PostResponseDTO
    {   
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Avatar_Url { get; set; }
        public string Title { get; set; }
        public string Body { get;set; }
        public DateTime CreateAt { get; set; }
        public int TotalLike { get; set; } = 0;
        public int TotalComment { get; set; } = 0;
    }
}
