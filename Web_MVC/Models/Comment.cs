using System;
using System.Collections.Generic;

namespace Web_MVC.Models;

public partial class Comment
{
    public int Id { get; set; }

    public long ProductId { get; set; }

    public int AccountId { get; set; }

    public int? ParentCommentId { get; set; }

    public string Comment1 { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
