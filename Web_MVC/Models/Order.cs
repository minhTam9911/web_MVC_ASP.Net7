using System;
using System.Collections.Generic;

namespace Web_MVC.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime OrderDate { get; set; }

    public string? Status { get; set; }

    public double TotalPrice { get; set; }

    public int AccountId { get; set; }

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? PaymentMethod { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
