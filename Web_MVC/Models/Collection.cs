using System;
using System.Collections.Generic;

namespace Web_MVC.Models;

public partial class Collection
{
    public int Id { get; set; }

    public long ProductId { get; set; }

    public string SizeOption { get; set; } = null!;

    public int AccountId { get; set; }

    public string? Description { get; set; }

    public virtual Product Product { get; set; } = null!;
}
