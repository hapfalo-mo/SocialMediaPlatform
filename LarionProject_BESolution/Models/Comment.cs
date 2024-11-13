using System;
using System.Collections.Generic;

namespace Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public int CreateBy { get; set; }

    public int? ParrentId { get; set; }

    public int PostId { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual User CreateByNavigation { get; set; } = null!;

    public virtual ICollection<Comment> InverseParrent { get; set; } = new List<Comment>();

    public virtual Comment? Parrent { get; set; }
    
}
