using System;
using System.Collections.Generic;

namespace Web_MVC.Models;

public partial class Product
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public string? Description { get; set; }

    public string Image { get; set; } = null!;

    public int CategoryId { get; set; }

    public int DiscountId { get; set; }

    public int SupplierId { get; set; }

    public string? Summary { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public short? Rating { get; set; }

    public string? Gender { get; set; }

    public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Collection> Collections { get; set; } = new List<Collection>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Discount Discount { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<ProductSizeOption> ProductSizeOptions { get; set; } = new List<ProductSizeOption>();

    public virtual Supplier Supplier { get; set; } = null!;
}
