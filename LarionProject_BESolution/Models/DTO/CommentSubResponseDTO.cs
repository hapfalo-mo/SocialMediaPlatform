using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class CommentSubResponseDTO
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
        public int CreateBy { get; set; }
        public string CreateAt { get; set; }
        public int? ParrentId { get; set; }
        public string? UserName { get; set; }
        public string? UserAvatar { get; set; }
    }
}
