using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class CommentDTO
    {
        public string Content { get; set; }
        public int CreateBy { get; set; }
        public int PostId { get; set; }
        public int? ParrentId { get; set; }
    }
}
