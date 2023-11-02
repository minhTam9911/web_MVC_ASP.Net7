using System;
using System.Collections.Generic;

namespace Web_MVC.Models;

public partial class Cart
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();
}
