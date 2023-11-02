using System;
using System.Collections.Generic;

namespace Web_MVC.Models;

public partial class Apitoken
{
    public int Id { get; set; }

    public string TokenRefresh { get; set; } = null!;

    public int AccountId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ExpireDate { get; set; }

    public virtual Account Account { get; set; } = null!;
}
