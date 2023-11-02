using System;
using System.Collections.Generic;

namespace Web_MVC.Models;

public partial class ProductSizeOption
{
    public long ProductId { get; set; }

    public string SizeOption { get; set; } = null!;

    public int QuantityStock { get; set; }

    public int QuantitySold { get; set; }

    public string? Description { get; set; }

    public virtual Product Product { get; set; } = null!;
}
