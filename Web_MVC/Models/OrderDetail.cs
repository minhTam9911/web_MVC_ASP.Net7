using System;
using System.Collections.Generic;

namespace Web_MVC.Models;

public partial class OrderDetail
{
    public int OrderId { get; set; }

    public long ProductId { get; set; }

    public string SizeOption { get; set; } = null!;

    public int Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
