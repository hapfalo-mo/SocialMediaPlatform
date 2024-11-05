using System;
using System.Collections.Generic;

namespace Models;

public partial class Post
{
    public int PostId { get; set; }

    public string? Title { get; set; }

    public string? Body { get; set; }

    public int UserId { get; set; }

    public int Status { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public string? ImgURL { get; set; }
   
    public virtual User User { get; set; } = null!;
    
    public virtual ICollection<Likes> Likes { get; set; } = new List<Likes>();

}
