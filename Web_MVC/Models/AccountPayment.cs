using System;
using System.Collections.Generic;

namespace Web_MVC.Models;

public partial class AccountPayment
{
    public long Id { get; set; }

    public int AccountId { get; set; }

    public DateTime Created { get; set; }

    public string? PaymentType { get; set; }
}
